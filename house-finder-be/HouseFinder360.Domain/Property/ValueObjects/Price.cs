using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class Price:ValueObject
{
    public int Value { get; private set; }
    public string Currency { get; private set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return Currency;
    }

    public Price(int value, string currency)
    {
        Value = value;
        Currency = currency;
    }

    private Price()
    {
    }
}