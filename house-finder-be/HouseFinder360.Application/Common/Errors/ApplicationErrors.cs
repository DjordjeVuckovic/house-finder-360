using FluentResults;
using HouseFinder360.Domain.Common.Errors;

namespace HouseFinder360.Application.Common.Errors;

public static class ApplicationErrors
{
    public static class Generic
    {
        public static readonly IError BadRequest = ErrorMessage.BadRequest("Invalid data provided.");
        public static readonly IError InvalidArgument = ErrorMessage.BadRequest("Invalid data supplied.");
        public static readonly IError NotFound = ErrorMessage.NotFound("Accessed resource not found.");
        public static readonly IError Forbidden =  ErrorMessage.Forbidden("Access to resource is restricted.");
        public static readonly IError Conflict = ErrorMessage.Conflict("Conflict exception.");   
    }
    public static class User
    {
        public static readonly IError WrongCredential = ErrorMessage.Conflict("Bad credentials!");
    }
    
}