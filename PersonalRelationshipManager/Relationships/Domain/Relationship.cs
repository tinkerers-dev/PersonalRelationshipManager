using PersonalRelationshipManager.Relationships.Domain.ValueObjects;

namespace PersonalRelationshipManager.Relationships.Domain;

public class Relationship(RelationshipId id)
{
    private readonly RelationshipId _id = id;

    public RelationshipId GetId()
    {
        return _id;
    }
}