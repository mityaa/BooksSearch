using Configuration.Interfaces;

namespace Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfigurationSource _configuration;

        public AppSettings(IConfigurationSource configuration)
        {
            _configuration = configuration;
        }

        public string? MongoConnectionString => Convert.ToString(_configuration.GetSetting(nameof(MongoConnectionString))?.Value);
        public string? DbName => Convert.ToString(_configuration.GetSetting(nameof(DbName))?.Value);
        public string? BooksDirectory => Convert.ToString(_configuration.GetSetting(nameof(BooksDirectory))?.Value);
        public string? SchedulerIntervalSeconds =>
            Convert.ToString(_configuration.GetSetting(nameof(SchedulerIntervalSeconds))?.Value);
    }
}