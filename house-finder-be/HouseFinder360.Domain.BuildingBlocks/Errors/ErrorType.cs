namespace HouseFinder360.Domain.BuildingBlocks.Errors;

public enum ErrorType
{
    Failure,
    Unexpected = 500,
    Conflict = 409,
    NotFound = 404,
    BadRequest = 400,
    Forbidden = 403
}
