using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccessLayer.Configuration.Interfaces;
using DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DataAccessLayer.Repositories
{
    class BookRepository : Repository, IBookRepository
    {
        public BookRepository(IAppSettings appSettings) : base(appSettings)
        {
        }

        public async Task<IList<string>> GetBooksByText(string text)
        {
            var booksInDb = await _mongoDatabase.GetCollection<Book>("Books")
                .Find(new BsonDocument("$text", new BsonDocument("$search", text)))
                .ToListAsync();


            //var result = await booksInDb.Find(Builders<Book>.Filter.Not(
            //    Builders<Book>.Filter
            //        .ElemMatch(x => x.Pages, p => !p.PageText.Contains($"/{text}/"))))
            //    .ToListAsync();

            return booksInDb.Select(x => x.BookFilePath).ToList();
        }

        public async void SaveBooksInDb(IList<Book> books)
        {
            var booksInDb = _mongoDatabase.GetCollection<Book>("Books");
            await booksInDb.InsertManyAsync(books);
        }

        public bool IfBookExistsInDB(string path)
        {
            try
            {
                var booksInDb = _mongoDatabase.GetCollection<Book>("Books");
                var filter = Builders<Book>.Filter.Eq(x => x.BookFilePath, path);
                var res = booksInDb.FindSync(filter).First();

                return res != null;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
