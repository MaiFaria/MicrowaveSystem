﻿namespace MicrowaveSystem.Core.Contexts;

public static class Configuration
{
    public static SecretsConfiguration Secrets { get; set; } = new();
    public static DatabaseConfiguration Database { get; set; } = new();

    public class SecretsConfiguration
    {
        public string ApiKey { get; set; } = string.Empty;
    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}

