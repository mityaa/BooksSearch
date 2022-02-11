using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Configuration.Interfaces;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories
{
    abstract class Repository
    {
        protected MongoClient _client;
        protected IMongoDatabase _mongoDatabase;

        protected Repository(IAppSettings appSettings)
        {
            _client = new MongoClient(appSettings.MongoConnectionString);
            _mongoDatabase = _client.GetDatabase(appSettings.DbName);
        }
    }
}
