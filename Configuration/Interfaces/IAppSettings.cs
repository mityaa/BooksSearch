﻿namespace Configuration.Interfaces
{
    public interface IAppSettings
    {
        string? MongoConnectionString { get; }
        string? DbName { get; }
    }
}