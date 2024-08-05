using PersonalRelationshipManager.Relationships.Domain;
using PersonalRelationshipManager.Relationships.Infrastructure.Persistence;
using PersonalRelationshipManager.Shared.Infrastructure.Persistence;

namespace PersonalRelationshipManager.Relationships.Integration.Persistence;

public class RelationshipMapper : IMapper<Relationship, RelationshipData>
{
    public RelationshipData ToDatabase(Relationship domain)
    {
        return new RelationshipData(
            domain.GetId().Value,
            domain.GetType().Value,
            domain.GetName().Value,
            domain.GetNickname().Value,
            domain.GetPhone().Value,
            domain.GetEmail().Value,
            domain.GetContactMethods().Value
        );
    }

    public Relationship ToDomain(RelationshipData database)
    {
        return new Relationship(
            database.Id,
            database.Type,
            database.Name,
            database.Nickname,
            database.Phone,
            database.Email,
            database.ContactMethods
        );
    }
}