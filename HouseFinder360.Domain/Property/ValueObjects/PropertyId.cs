using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.ValueObjects;

public class PropertyId : ValueObject
{
    public Guid Value { get; private set; }

    private PropertyId(Guid value)
    {
        Value = value;
    }

    public static PropertyId CreateUnique()
    {
        return new PropertyId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}