using HouseFinder360.BuildingBlocks.BuildingBlocks;

namespace HouseFinder360.Domain.Properties.ValueObjects;

public class PropertyId : ValueObject
{
    public Guid Id { get; private set; }

    private PropertyId(Guid id)
    {
        Id = id;
    }

    public static PropertyId CreateUnique()
    {
        return new PropertyId(Guid.NewGuid());
    }

    private PropertyId()
    {
        Id = new Guid();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}