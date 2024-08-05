namespace PersonalRelationshipManager.Relationships.Application;

public record CreateRelationshipDto(
    string Type,
    string Name,
    string Nickname,
    string Phone,
    string Email,
    string[] ContactMethods)
{
}