using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Configuration
{
    sealed class ConfigurationSource : DataAccessLayer.Configuration.Interfaces.IConfigurationSource
    {
        private IConfigurationRoot config;

        public ConfigurationValue GetSetting(string name)
        {
            return getSettingConfigurationValue(name);
        }

        internal IConfigurationRoot ConfigurationRoot
        {
            get =>
                config ??= new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            set => config = value;
        }

        private ConfigurationValue getSettingConfigurationValue(string name)
        {
            var value = System.Environment.GetEnvironmentVariable(name) ?? ConfigurationRoot.GetSection("appSettings")[name];

            return value == null ? null : new ConfigurationValue(name, value);
        }
    }
}