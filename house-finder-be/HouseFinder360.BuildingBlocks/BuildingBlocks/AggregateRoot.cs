namespace HouseFinder360.BuildingBlocks.BuildingBlocks;

public class AggregateRoot<TId> : Entity<TId> 
    where TId : notnull
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot()
    {
    }
}