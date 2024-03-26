using System.Linq.Expressions;
using System.Text.Json;

namespace HouseFinder360.Domain.BuildingBlocks.EventSourcing;

public interface IEventQueryable
{
    IEventQueryable After(DateTime moment);
    IEventQueryable Before(DateTime moment);
    IEventQueryable Where(Expression<Func<JsonDocument, bool>> condition);
    List<DomainEvent> ToList();
    List<T> ToList<T>() where T : DomainEvent;
}
