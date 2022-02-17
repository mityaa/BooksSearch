using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    interface IBookRepository
    {
        Task<IList<string>> GetBooksByText(string text);
        void SaveBooksInDb(IList<Book> books);
        void CreatePageTextIndex();
        bool IfBookExistsInDb(string path);
    }
}
