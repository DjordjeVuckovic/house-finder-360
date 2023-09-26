using HouseFinder360.Domain.BuildingBlocks.Common.Pagination;

namespace HouseFinder360.Domain.BuildingBlocks.EventSourcing;

public interface IEventStore<T> where T : notnull
{
    void Save(EventSourcedAggregateRoot<T> aggregate);
    IEventQueryable Events { get; }
    Task<PagedResult<DomainEvent>> GetEventsAsync(int page, int pageSize);
}