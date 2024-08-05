using System.Data;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Persistence;

public class RelationshipData
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string[] ContactMethods { get; set; }

    public RelationshipData(Guid id, string type, string name, string nickname, string phone, string email, string[] contactMethods)
    {
        Id = id;
        Type = type;
        Name = name;
        Nickname = nickname;
        Phone = phone;
        Email = email;
        ContactMethods = contactMethods;
    }

    public RelationshipData()
    {
    }
} 