using System.Collections.Generic;
using System.Threading.Tasks;
using Configuration;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace DataAccessLayer
{
    public interface IBookService
    {
        void SaveBooksInDb(IList<Book> books);
        void CreatePageTextIndex();
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

        public void CreatePageTextIndex()
        {
            _bookRepository.CreatePageTextIndex();
        }

        public bool IfBookExistsInDb(string bookPath)
        {
            return _bookRepository.IfBookExistsInDb(bookPath);
        }

        public async Task<IList<string>> SearchBooksByWord(string word)
        {
            return await _bookRepository.GetBooksByText(word);
        }
    }
}
