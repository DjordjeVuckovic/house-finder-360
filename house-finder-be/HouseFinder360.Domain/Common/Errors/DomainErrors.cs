using FluentResults;

namespace HouseFinder360.Domain.Common.Errors;

public static class DomainErrors
{
    public static class Database
    {
        public static readonly IError Conflict = ErrorMessage.Conflict("Database persistence conflict exception.");
        public static readonly IError TransactionConflict = ErrorMessage.Conflict("No active transaction");
    }
}