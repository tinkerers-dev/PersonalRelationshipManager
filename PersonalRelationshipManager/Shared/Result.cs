namespace PersonalRelationshipManager.Shared;

public class Result<TValue>
{
    private Result(TValue? value)
    {
        _value = value;
        _error = default;
    }

    private Result(Exception error)
    {
        _value = default;
        _error = error;
    }

    private readonly TValue? _value;
    private readonly Exception? _error;

    public static Result<TValue> Ok(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static Result<TValue> Failure(Exception error)
    {
        return new Result<TValue>(error);
    }

    public TValue Value
    {
        get
        {
            if (IsFailure())
            {
                throw new InvalidOperationException("No value for failure result");
            }

            return _value!;
        }
    }

    public Exception Error
    {
        get
        {
            if (IsSuccess())
            {
                throw new InvalidOperationException("No error for success result");
            }

            return Error!;
        }
    }

    public bool IsSuccess()
    {
        return _value != null && _error == null;
    }

    public bool IsFailure()
    {
        return _error != null && _value == null;
    }
}