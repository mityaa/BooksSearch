using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Path = iTextSharp.text.pdf.parser.Path;
using SearchOption = Microsoft.VisualBasic.FileIO.SearchOption;

namespace BookDirectoryScheduler
{
    static class PdfParser
    {
        public static BlockingCollection<Book> GetAllParsedBooks(string directory, Func<string, bool> ifBookExistsAction)
        {
            var files = GetAllPathsFromDirectory(directory);
            var threadSavedFiles = new BlockingCollection<string>(new ConcurrentQueue<string>(files));

            foreach (var file in threadSavedFiles)
            {
                if (!ifBookExistsAction(file)) continue;

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

        private static Book ParseBook(string path)
        {
            var reader = new PdfReader(path);
            var book = new Book { Pages = new List<Page>(), BookFilePath = path};

            for (var i = 1; i <= reader.NumberOfPages; i++)
            {
                var page = new Page
                {
                    PageText = PdfTextExtractor.GetTextFromPage(reader, i)
                };
                book.Pages.Add(page);
            }
            reader.Close();
            return book;
        }

        private static IList<string> GetAllPathsFromDirectory(string directory)
        {
            return Directory.GetFiles(directory, "*.pdf");
        }
    }
}
