using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record Name(string Value) : ValueObject<string>(Value)
{
}