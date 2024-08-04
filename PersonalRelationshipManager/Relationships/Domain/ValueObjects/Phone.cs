using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record Phone(string Value) : ValueObject<string>(Value)
{
}