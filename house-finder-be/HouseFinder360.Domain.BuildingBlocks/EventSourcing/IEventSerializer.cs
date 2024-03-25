using System.Text.Json;

namespace HouseFinder360.Domain.BuildingBlocks.EventSourcing;

public interface IEventSerializer
{
    JsonDocument Serialize(DomainEvent @event);
    DomainEvent Deserialize(JsonDocument @event);
}
