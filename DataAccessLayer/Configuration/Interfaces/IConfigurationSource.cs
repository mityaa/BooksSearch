﻿namespace DataAccessLayer.Configuration.Interfaces
{
    public interface IConfigurationSource
    {
        ConfigurationValue GetSetting(string name);
    }
}