using PersonalRelationshipManager.Relationships.Domain.ValueObjects;

namespace PersonalRelationshipManager.Relationships.Domain.Repositories;

public interface IRelationshipsRepository
{
    Task SaveRelationship(Relationship relationship);
    Task<Relationship> FindRelationshipById(RelationshipId id);
}