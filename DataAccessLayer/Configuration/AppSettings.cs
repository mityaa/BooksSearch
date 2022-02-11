using System;
using DataAccessLayer.Configuration.Interfaces;

namespace DataAccessLayer.Configuration
{
    public class AppSettings : IAppSettings
    {
        private IConfigurationSource _configuration;

        public AppSettings(IConfigurationSource configuration)
        {
            _configuration = configuration;
        }

        public string MongoConnectionString => Convert.ToString(_configuration.GetSetting(nameof(MongoConnectionString)).Value);
        public string DbName => Convert.ToString(_configuration.GetSetting(nameof(DbName)).Value);
    }
}