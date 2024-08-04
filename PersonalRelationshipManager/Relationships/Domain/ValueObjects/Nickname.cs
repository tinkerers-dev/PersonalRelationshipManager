using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record Nickname(string Value) : ValueObject<string>(Value)
{
}