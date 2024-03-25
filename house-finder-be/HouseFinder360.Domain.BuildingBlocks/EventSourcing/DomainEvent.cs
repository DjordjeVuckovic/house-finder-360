namespace HouseFinder360.Domain.BuildingBlocks.EventSourcing;

public abstract class DomainEvent
{
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}
