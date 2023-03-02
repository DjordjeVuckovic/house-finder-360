using FluentResults;

namespace HouseFinder360.Application.Common.Errors;

public class ErrorMessage : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; protected set;}
    public List<IError> Reasons { get; protected init; }
    public ErrorType StatusCode { get; protected init; }

    protected ErrorMessage(string message)
    {
        Message = message;
        Metadata = new Dictionary<string, object>
        {
            { "Message: ", message}
        };
        Reasons = new List<IError>{new Error(message)};
    }

    public static ErrorMessage Conflict(string message)
    {
        return new ErrorMessage(message)
        {
            StatusCode = ErrorType.Conflict
        };
    }
    public static ErrorMessage BadRequest(string message)
    {
        return new ErrorMessage(message)
        {
            StatusCode = ErrorType.BadRequest
        };
    }
    public static ErrorMessage NotFound(string message)
    {
        return new ErrorMessage(message)
        {
            StatusCode = ErrorType.BadRequest
        };
    }
    public static ErrorMessage Forbidden(string message)
    {
        return new ErrorMessage(message)
        {
            StatusCode = ErrorType.Forbidden
        };
    }
    public static ErrorMessage Validation(string message)
    {
        return new ErrorMessage(message)
        {
            StatusCode = ErrorType.Forbidden
        };
    }
}