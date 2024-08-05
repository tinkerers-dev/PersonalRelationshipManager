using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Domain.Repositories;
using PersonalRelationshipManager.Relationships.Domain.ValueObjects;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Persistence;

public class PostgresRelationshipsRepository : IRelationshipRepository
{
    private readonly IOptions<DatabaseSettings> _databaseSettings;
    private readonly IMapper<Relationship, RelationshipData> _relationshipMapper;

    public PostgresRelationshipsRepository(IOptions<DatabaseSettings> databaseSettings,
        IMapper<Relationship, RelationshipData> relationshipMapper)
    {
        _databaseSettings = databaseSettings;
        _relationshipMapper = relationshipMapper;
    }

    private IDbConnection Connection => new NpgsqlConnection(_databaseSettings.Value.ConnectionString);

    public async Task SaveRelationship(Relationship relationship)
    {
        var relationshipData = _relationshipMapper.ToDatabase(relationship);
        var sql =
            "INSERT INTO Relationships (Id, Type, Name, Nickname,Phone, Email, ContactMethods) VALUES (@Id, @Type, @Name, @Nickname, @Phone, @Email, @ContactMethods)";

        await Connection.ExecuteAsync(
            sql,
            relationshipData);
    }

    public async Task<Relationship> FindRelationshipById(RelationshipId id)
    {
        var sql = $"SELECT * FROM Relationships WHERE Id = '{id.Value}'";

        var relationshipData = await Connection.QuerySingleAsync<RelationshipData>(sql);
        return _relationshipMapper.ToDomain(relationshipData);
    }
}