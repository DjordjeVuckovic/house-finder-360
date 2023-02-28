namespace HouseFinder360.Application.Common.Errors;

public class BadRequestError : ErrorMessage
{
    public BadRequestError(string message) : base(message)
    {
        StatusCode = 400;
    }
    
}