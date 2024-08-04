using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record RelationshipType(string Value) : ValueObject<string>(Value)
{
}