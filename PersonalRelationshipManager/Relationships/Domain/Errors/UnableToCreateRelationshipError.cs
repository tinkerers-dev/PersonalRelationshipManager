namespace PersonalRelationshipManager.Relationships.Domain.Errors;

public class UnableToCreateRelationshipError : Exception
{
    private readonly Exception? _exception;

    public UnableToCreateRelationshipError(Exception exception)
    {
        _exception = exception;
    }

    public UnableToCreateRelationshipError()
    {
    }
}