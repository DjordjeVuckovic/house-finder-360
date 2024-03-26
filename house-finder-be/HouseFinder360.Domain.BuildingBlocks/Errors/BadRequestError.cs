using FluentResults;

namespace HouseFinder360.Domain.BuildingBlocks.Errors;

public class BadRequestError : ErrorMessage
{
    public BadRequestError(string message) : base(message)
    {
        StatusCode = ErrorType.BadRequest;
        Reasons = new List<IError> { new Error(message) };
    }

}
