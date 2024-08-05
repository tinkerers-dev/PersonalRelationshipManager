namespace PersonalRelationshipManager.Shared.Infrastructure;

public class DefaultGuidService: IGuidService
{
    public Guid RandomGuid()
    {
        return Guid.NewGuid();
    }
}