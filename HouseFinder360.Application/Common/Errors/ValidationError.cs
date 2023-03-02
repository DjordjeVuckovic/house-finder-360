namespace HouseFinder360.Application.Common.Errors;

public class ValidationError : ErrorMessage
{
    public string PropertyName { get; }
    public ValidationError(string message,string propertyName) : base(message)
    {
        PropertyName = propertyName;
        Metadata = new Dictionary<string, object>
        {
            { propertyName, message}
        };
        StatusCode = ErrorType.BadRequest;
    }
}