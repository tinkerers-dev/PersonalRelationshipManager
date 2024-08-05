using PersonalRelationshipManager.Relationships.Domain.ValueObjects;

namespace PersonalRelationshipManager.Relationships.Domain.Repositories;

public interface IRelationshipRepository
{
    Task SaveRelationship(Relationship relationship);
    Task<Relationship> FindRelationshipById(RelationshipId id);
}