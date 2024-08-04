using PersonalRelationshipManager.Relationships.Application;
using PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;

namespace PersonalRelationshipManager.Tests.Builders;

public class CreateRelationshipDtoBuilder
{
    private readonly string _type;
    private string _name = "John Doe";
    private string _nickname = "Jonny";
    private string _phone = "123456789";
    private string _email = "john.doe@gmail.com";

    private string[] _contactMethods = new[]
    {
        "WhatsApp",
        "Telegram",
    };

    private CreateRelationshipDtoBuilder(string type)
    {
        _type = type;
    }

    public static CreateRelationshipDtoBuilder AFriend()
    {
        return new CreateRelationshipDtoBuilder("friend");
    }

    public CreateRelationshipDtoBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CreateRelationshipDtoBuilder WithNickname(string nickname)
    {
        _nickname = nickname;
        return this;
    }

    public CreateRelationshipDtoBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public CreateRelationshipDtoBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public CreateRelationshipDtoBuilder WithContactMethods(params string[] contactMethods)
    {
        _contactMethods = contactMethods;
        return this;
    }

    public CreateRelationshipDto Build()
    {
        return new CreateRelationshipDto(
            _type,
            _name,
            _nickname,
            _phone,
            _email,
            _contactMethods
        );
    }
}

public class CreateRelationshipRequestBuilder
{
    private string _type = "friend";
    private string _name = "John Doe";
    private string _nickname = "Jonny";
    private string _phone = "123456789";
    private string _email = "john.doe@gmail.com";

    private string[] _contactMethods = new[]
    {
        "WhatsApp",
        "Telegram",
    };

    private CreateRelationshipRequestBuilder(string type)
    {
        _type = type;
    }

    public static CreateRelationshipRequestBuilder AFriend()
    {
        return new CreateRelationshipRequestBuilder("friend");
    }

    public CreateRelationshipRequestBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public CreateRelationshipRequestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CreateRelationshipRequestBuilder WithNickname(string nickname)
    {
        _nickname = nickname;
        return this;
    }

    public CreateRelationshipRequestBuilder WithPhone(string phone)
    {
        _phone = phone;
        return this;
    }

    public CreateRelationshipRequestBuilder WithEmail(string email)
    {
        _email = email;
        return this;
    }

    public CreateRelationshipRequestBuilder WithContactMethods(params string[] contactMethods)
    {
        _contactMethods = contactMethods;
        return this;
    }

    public CreateRelationshipRequest Build()
    {
        return new CreateRelationshipRequest
        {
            Type = _type,
            Name = _name,
            NickName = _nickname,
            Phone = _phone,
            Email = _email,
            ContactMethods = _contactMethods
        };
    }
}