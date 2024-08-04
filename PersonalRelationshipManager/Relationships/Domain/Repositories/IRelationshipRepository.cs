namespace PersonalRelationshipManager.Relationships.Domain.Repositories;

public interface IRelationshipRepository
{
    Task SaveRelationship(Relationship relationship);
}