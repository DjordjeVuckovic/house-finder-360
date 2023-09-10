using FluentResults;
using HouseFinder360.Domain.BuildingBlocks.DDD;
using HouseFinder360.RealEstates.Domain.Common.Errors;

namespace HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

public class Price:ValueObject
{
    public int Value { get; private set; }
    public string Currency { get; private set; } = null!;
    private static readonly string[] PossibleCurrencies = { "euro", "dollar" };

    public static string PossibleCurrenciesToString()
    {
        return PossibleCurrencies.ToList().ToString()!;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    private Price(int value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    public static Result<Price> CreatePrice(int value, string currency)
    {
        if (!PossibleCurrencies
                .Any(x => string.Equals(
                    x,
                    currency,
                    StringComparison.CurrentCultureIgnoreCase)))
        {
            return Result.Fail(DomainErrors.PriceErrors.NotValidCurrency);
        }
        return new Price(value, currency);
    }

    private Price()
    {
    }
}