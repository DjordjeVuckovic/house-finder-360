namespace HouseFinder360.Domain.Common.Errors;

public enum ErrorType
{
    Failure,
    Unexpected = 500,
    Conflict=409,
    NotFound = 404,
    BadRequest = 400,
    Forbidden = 403
}