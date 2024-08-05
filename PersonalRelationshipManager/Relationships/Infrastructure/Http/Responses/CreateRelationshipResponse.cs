using PersonalRelationshipManager.Relationships.Domain.ValueObjects;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Http;

public record CreateRelationshipResponse
{
    public Guid Id { get; set; }

    public CreateRelationshipResponse(RelationshipId relationshipId)
    {
        Id = relationshipId.Value;
    }
}