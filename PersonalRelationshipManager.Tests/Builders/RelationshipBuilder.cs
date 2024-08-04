using PersonalRelationshipManager.Relationships.Domain;

namespace PersonalRelationshipManager.Tests.Builders;

public class RelationshipBuilder
{
    private readonly string _type;
    private Guid _id = Guid.NewGuid();
    private string _name = "John Doe";
    private string _nickname = "Jonny";
    private string _phone = "123456789";
    private string _email = "john.doe@gmail.com";

    private string[] _contactMethods = new[]
    {
        "WhatsApp",
        "Telegram",
    };

    private RelationshipBuilder(string type)
    {
        this._type = type;
    }

    public static RelationshipBuilder AFriend()
    {
        return new RelationshipBuilder("friend");
    }

    public RelationshipBuilder WithId(Guid id)
    {
        this._id = id;
        return this;
    }

    public RelationshipBuilder WithName(string name)
    {
        this._name = name;
        return this;
    }

    public RelationshipBuilder WithNickname(string nickname)
    {
        this._nickname = nickname;
        return this;
    }

    public RelationshipBuilder WithPhone(string phone)
    {
        this._phone = phone;
        return this;
    }

    public RelationshipBuilder WithEmail(string email)
    {
        this._email = email;
        return this;
    }

    public RelationshipBuilder WithContactMethods(params string[] contactMethods)
    {
        this._contactMethods = contactMethods;
        return this;
    }


    public Relationship Build()
    {
        return new Relationship(
            _id,
            _type,
            _name,
            _nickname,
            _phone,
            _email,
            _contactMethods
        );
    }
}