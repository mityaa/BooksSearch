using DataAccessLayer.Configuration.Interfaces;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories
{
    abstract class Repository
    {
        protected readonly IMongoDatabase MongoDatabase;

        protected Repository(IAppSettings appSettings)
        {
            var client = new MongoClient(appSettings.MongoConnectionString);
            MongoDatabase = client.GetDatabase(appSettings.DbName);
        }
    }
}
