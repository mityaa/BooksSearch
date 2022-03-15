using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataAccessLayer.Configuration.Interfaces;
using DataAccessLayer.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using MongoDB.Driver.Linq;
using static System.String;

namespace DataAccessLayer.Repositories
{
    class BookRepository : Repository, IBookRepository
    {
        private readonly Regex _sWhitespace = new(@"\s+");
        public BookRepository(IAppSettings appSettings) : base(appSettings)
        {
        }
        
        public async Task<IList<string>> GetBooksByText(string text)
        {
            var result = new List<string>();
            //clear whitespaces as we do in parser
            text = _sWhitespace.Replace(text, Empty);
            await GetBooksMongoCollection()
                .Find(new BsonDocument("$text", new BsonDocument("$search", text)))
                .ForEachAsync(x => result.Add(x.BookFilePath));


            return result;
        }

        public async void SaveBooksInDb(IList<Book> books)
        {
            var booksInDb = GetBooksMongoCollection();
            await booksInDb.InsertManyAsync(books);
        }

        public async void CreatePageTextIndex()
        {
            var books = GetBooksMongoCollection();
            var model = new CreateIndexModel<Book>(Builders<Book>.IndexKeys.Text("Pages.PageText"));
            await books.Indexes.CreateOneAsync(model).ConfigureAwait(false);
        }


        public bool IfBookExistsInDb(string path)
        {
            try
            {
                var booksInDb = GetBooksMongoCollection();
                var filter = Builders<Book>.Filter.Eq(x => x.BookFilePath, path);
                var res = booksInDb.FindSync(filter).Any();

                return res;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IMongoCollection<Book> GetBooksMongoCollection()
        {
            return MongoDatabase.GetCollection<Book>("Books");
        }
    }
}
