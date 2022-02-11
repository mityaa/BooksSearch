using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Configuration;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public interface IBookService
    {
        void SaveBooksInDb(IList<Book> books);
        bool IfBookExistsInDb(string bookPath);
        Task<IList<string>> SearchBooksByWord(string word);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService()
        {
            var appSettings = new AppSettings(new ConfigurationSource());
            _bookRepository = new BookRepository(appSettings);
        }

        public void SaveBooksInDb(IList<Book> books)
        {
            _bookRepository.SaveBooksInDb(books);
        }

        public bool IfBookExistsInDb(string bookPath)
        {
            return _bookRepository.IfBookExistsInDB(bookPath);
        }

        public async Task<IList<string>> SearchBooksByWord(string word)
        {
            return await _bookRepository.GetBooksByText(word);
        }
    }
}
