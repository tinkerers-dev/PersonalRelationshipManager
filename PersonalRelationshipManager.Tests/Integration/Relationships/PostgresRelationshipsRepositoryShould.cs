using FluentAssertions;
using Microsoft.Extensions.Options;
using PersonalRelationshipManager.Relationships.Infrastructure.Persistence;
using PersonalRelationshipManager.Relationships.Integration.Persistence;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;
using PersonalRelationshipManager.Tests.Builders;
using Testcontainers.PostgreSql;

public class PostgresRelationshipsRepositoryShould : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();
    private DatabaseSettings _databaseSettings;

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();

        _databaseSettings = new DatabaseSettings
        {
            ConnectionString = _postgreSqlContainer.GetConnectionString()
        };

        var migrationRunner = new MigrationRunner(Options.Create(_databaseSettings));
        await migrationRunner.RunMigrations();
    }

    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    [Fact]
    public async Task SaveAndRetrieveRelationshipFromDatabase()
    {
        var postgresRelationshipsRepository =
            new PostgresRelationshipsRepository(Options.Create(_databaseSettings), new RelationshipMapper());
        var relationship = RelationshipBuilder.AFriend().Build();

        await postgresRelationshipsRepository.SaveRelationship(relationship);

        var foundRelationship = await postgresRelationshipsRepository.FindRelationshipById(relationship.GetId());

        foundRelationship.Should().Be(relationship);
    }
}