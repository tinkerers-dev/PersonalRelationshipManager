using System.Reflection;
using DbUp;
using Microsoft.Extensions.Options;

namespace PersonalRelationshipManager.Shared.Infrastructure.Persistence;

public class MigrationRunner
{
    private readonly IOptions<DatabaseSettings> _databaseSettings;

    public MigrationRunner(IOptions<DatabaseSettings> databaseSettings)
    {
        _databaseSettings = databaseSettings;
    }

    public async Task RunMigrations()
    {
        var upgradeEngine = DeployChanges.To
            .PostgresqlDatabase(_databaseSettings.Value.ConnectionString)
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            .LogToConsole()
            .Build();

        if (upgradeEngine.IsUpgradeRequired())
        {
            upgradeEngine.PerformUpgrade();
            upgradeEngine.MarkAsExecuted();
        }
    }
}