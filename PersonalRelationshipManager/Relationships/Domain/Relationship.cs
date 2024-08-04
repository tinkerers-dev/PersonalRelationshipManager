using PersonalRelationshipManager.Relationships.Domain.ValueObjects;

namespace PersonalRelationshipManager.Relationships.Domain;

public class Relationship
{
    private readonly RelationshipId _id;
    private readonly RelationshipType _type;
    private readonly Name _name;
    private readonly Nickname _nickname;
    private readonly Phone _phone;
    private readonly Email _email;
    private readonly ContactMethods _contactMethods;

    public Relationship(RelationshipId id,
        RelationshipType type,
        Name name,
        Nickname nickname,
        Phone phone,
        Email email,
        ContactMethods contactMethods)
    {
        _id = id;
        _type = type;
        _name = name;
        _nickname = nickname;
        _phone = phone;
        _email = email;
        _contactMethods = contactMethods;
    }

    public Relationship(
        Guid id,
        string type,
        string name,
        string nickname,
        string phone,
        string email,
        string[] contactMethods)
    {
        _id = new RelationshipId(id);
        _name = new Name(name);
        _type = new RelationshipType(type);
        _nickname = new Nickname(nickname);
        _phone = new Phone(phone);
        _email = new Email(email);
        _contactMethods = new ContactMethods(contactMethods);
    }

    public RelationshipId GetId()
    {
        return _id;
    }
}