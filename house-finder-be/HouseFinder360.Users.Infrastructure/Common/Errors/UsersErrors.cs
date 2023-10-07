using FluentResults;
using HouseFinder360.Domain.BuildingBlocks.Errors;

namespace HouseFinder360.Users.Infrastructure.Common.Errors;

public static class UsersErrors
{
    public static readonly IError WrongCredential = ErrorMessage.Forbidden("Bad credentials!");
    public static IError WrongCredentialForUser(string email) => ErrorMessage.Forbidden($"Bad credentials for user {email}.Please check it again!");
    public static readonly IError CannotGenerateToken = ErrorMessage.Forbidden("Cannot generate token");
    public static readonly IError RegisterFailed = ErrorMessage.BadRequest("You cannot register new account at the moment!");
    public static readonly IError RoleAssign = ErrorMessage.BadRequest("Cannot assign role role!");
    public static readonly IError Role = ErrorMessage.BadRequest("Wrong role!");
}