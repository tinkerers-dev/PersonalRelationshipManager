using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record Email(string Value) : ValueObject<string>(Value)
{
}