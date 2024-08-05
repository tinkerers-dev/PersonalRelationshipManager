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

    public RelationshipType GetType()
    {
        return _type;
    }

    public Name GetName()
    {
        return _name;
    }

    public Nickname GetNickname()
    {
        return _nickname;
    }

    public Phone GetPhone()
    {
        return _phone;
    }

    public Email GetEmail()
    {
        return _email;
    }

    public ContactMethods GetContactMethods()
    {
        return _contactMethods;
    }

    protected bool Equals(Relationship other)
    {
        return _id.Equals(other._id);
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || obj is Relationship other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }

    public static bool operator ==(Relationship? left, Relationship? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Relationship? left, Relationship? right)
    {
        return !Equals(left, right);
    }
}