using FluentResults;

namespace HouseFinder360.Application.Common.Errors;

public class ErrorMessage : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; }
    public List<IError> Reasons { get; }
    public int StatusCode { get; protected set; }

    public ErrorMessage(string message)
    {
        Message = message;
        Metadata = new Dictionary<string, object>
        {
            { "Message: ", message}
        };
        Reasons = new List<IError>();
    }
}