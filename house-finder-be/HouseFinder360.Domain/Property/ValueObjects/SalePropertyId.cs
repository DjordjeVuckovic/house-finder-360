using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class SalePropertyId : ValueObject
{
    public Guid Value { get; private set; }

    private SalePropertyId(Guid value)
    {
        Value = value;
    }

    public static SalePropertyId CreateUnique()
    {
        return new SalePropertyId(Guid.NewGuid());
    }

    private SalePropertyId()
    {
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}