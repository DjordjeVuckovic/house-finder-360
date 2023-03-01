using FluentResults;

namespace HouseFinder360.Application.Common.Errors;

public static class ErrorResults
{
    public static class Generic
    {
        public static readonly IError BadRequest = new Error("Invalid data provided.");
        public static readonly IError InvalidArgument = new Error("Invalid data supplied.");
        public static readonly IError NotFound = new Error("Accessed resource not found.");
        public static readonly IError Forbidden = new Error("Access to resource is restricted.");
        public static readonly IError Conflict = new Error("Database persistence conflict exception.");   
    }
    public static class User
    {
        public static readonly IError DuplicateEmail = new Error("Duplicate email error");
    }
    
}