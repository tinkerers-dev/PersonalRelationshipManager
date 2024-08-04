using PersonalRelationshipManager.Shared;

namespace PersonalRelationshipManager.Relationships.Domain.ValueObjects;

public record ContactMethods(string[] Value) : ValueObject<string[]>(Value)
{
}