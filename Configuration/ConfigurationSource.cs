using Microsoft.Extensions.Configuration;
using IConfigurationSource = Configuration.Interfaces.IConfigurationSource;

namespace Configuration
{
    public sealed class ConfigurationSource : IConfigurationSource
    {
        private IConfigurationRoot _config;

        public ConfigurationValue? GetSetting(string name)
        {
            return GetSettingConfigurationValue(name);
        }

        private IConfigurationRoot ConfigurationRoot
        {
            get =>
                _config ??= new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();

            set => _config = value;
        }

        private ConfigurationValue? GetSettingConfigurationValue(string name)
        {
            var value = System.Environment.GetEnvironmentVariable(name) ?? ConfigurationRoot.GetSection("appSettings")[name];

            return value == null ? null : new ConfigurationValue(name, value);
        }
    }
}