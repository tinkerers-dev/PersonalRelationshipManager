namespace PersonalRelationshipManager.Shared.Infrastructure.Persistence;

public interface IMigrationRunner
{
    Task RunMigrations();
}