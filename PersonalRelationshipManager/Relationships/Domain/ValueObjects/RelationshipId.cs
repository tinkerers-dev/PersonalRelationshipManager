using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record RelationshipId(Guid Value) : ValueObject<Guid>(Value)
{
}