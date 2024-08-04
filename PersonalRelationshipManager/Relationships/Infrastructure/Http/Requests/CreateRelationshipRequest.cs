using PersonalRelationshipManager.Relationships.Application;

namespace PersonalRelationshipManager.Relationships.Infrastructure.Http.Requests;

public class CreateRelationshipRequest
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
    public string[] ContactMethods { get; set; }

    public CreateRelationshipDto ToDto()
    {
        return new CreateRelationshipDto(
            Type,
            Name,
            NickName,
            Phone,
            Email,
            ContactMethods
        );
    }
}