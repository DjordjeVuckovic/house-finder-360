using FluentResults;
using HouseFinder360.Domain.BuildingBlocks.Errors;

namespace HouseFinder360.Users.Infrastructure.Errors;

public static class UsersErrors
{
    public static readonly IError WrongCredential = ErrorMessage.Forbidden("Bad credentials!");
    public static readonly IError RegisterFailed = ErrorMessage.BadRequest("You cannot register new account at the moment!");
    public static readonly IError RoleAssign = ErrorMessage.BadRequest("Wrong role!");
}