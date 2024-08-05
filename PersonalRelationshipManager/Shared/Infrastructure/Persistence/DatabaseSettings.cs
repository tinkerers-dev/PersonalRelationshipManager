namespace PersonalRelationshipManager.Shared.Infrastructure.Persistence;

public class DatabaseSettings
{
    public string? ConnectionString { get; set; } = Environment.GetEnvironmentVariable("PG_CONNECTION_STRING");
}