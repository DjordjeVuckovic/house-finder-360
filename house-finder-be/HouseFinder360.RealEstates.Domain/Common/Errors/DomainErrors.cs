using FluentResults;
using HouseFinder360.Domain.BuildingBlocks.Errors;
using HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

namespace HouseFinder360.RealEstates.Domain.Common.Errors;

public static class DomainErrors
{
    public static class Database
    {
        public static readonly IError Conflict = ErrorMessage.Conflict("Database persistence conflict exception.");
        public static readonly IError TransactionConflict = ErrorMessage.Conflict("No active transaction");
    }

    public static class PriceErrors
    {
        public static readonly IError NotValidCurrency =
            new Error("Not valid currency.Possible currency values are " + Price.PossibleCurrenciesToString());

    }
    public static class AreaErrors
    {
        public static readonly IError NotValidArea =
            new Error("Area cannot be less then zero!");
    }
}
