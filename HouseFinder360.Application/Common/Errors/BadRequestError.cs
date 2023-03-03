using FluentResults;
using HouseFinder360.Domain.Common.Errors;

namespace HouseFinder360.Application.Common.Errors;

public class BadRequestError : ErrorMessage
{
    public BadRequestError(string message) : base(message)
    {
        StatusCode = ErrorType.BadRequest;
        Reasons = new List<IError>{new Error(message)};
    }
    
}