using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Configuration;
using DataAccessLayer;
using DataAccessLayer.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using static System.String;

namespace BookDirectoryScheduler
{
    internal class PdfParser
    {
        private readonly Regex _sWhitespace = new(@"\s+");
        private readonly IBookService _bookService;

        internal PdfParser()
        {
            _bookService = new BookService();

        }

        public BlockingCollection<Book> GetAllParsedBooks(string directory)
        {
            var files = GetAllPathsFromDirectory(directory);
            var threadSavedFiles = new BlockingCollection<string>(new ConcurrentQueue<string>(files));

            foreach (var file in threadSavedFiles)
            {
                if (!_bookService.IfBookExistsInDb(file)) continue;

                while (threadSavedFiles.TryTake(out _, TimeSpan.FromMilliseconds(100)))
                {
                    Console.WriteLine($"Book {file} was removed from collection because it already exists");
                }
            }

            var parsedFiles = new BlockingCollection<Book>();
            Parallel.ForEach(threadSavedFiles, file =>
            {
                var parsedBook = ParseBook(file);
                parsedFiles.Add(parsedBook);
            });

            return parsedFiles;
        }

        private Book ParseBook(string path)
        {
            var reader = new PdfReader(path);
            var book = new Book { Pages = new List<Page>(), BookFilePath = path};

            for (var i = 1; i <= reader.NumberOfPages; i++)
            {
                var page = new Page
                {
                    PageText = ReplaceWhitespace(PdfTextExtractor.GetTextFromPage(reader, i), Empty)
                };
                book.Pages.Add(page);
            }
            reader.Close();
            return book;
        }

        private string ReplaceWhitespace(string input, string replacement)
        {
            return _sWhitespace.Replace(input, replacement);
        }

        private IEnumerable<string> GetAllPathsFromDirectory(string directory)
        {
            return Directory.GetFiles(directory, "*.pdf");
        }
    }
}
