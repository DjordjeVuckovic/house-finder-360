namespace HouseFinder360.Application.BuildingBlocks.MessageBroker;

public interface IMessageBroker
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default);
    
    Task Publish<TNotification>(TNotification notification,CancellationToken cancellationToken = default);
}