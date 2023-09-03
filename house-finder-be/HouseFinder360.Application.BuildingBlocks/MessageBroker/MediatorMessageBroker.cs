using MediatR;

namespace HouseFinder360.Application.BuildingBlocks.MessageBroker;

public class MediatorMessageBroker : IMessageBroker
{
    private readonly IMediator _mediator;

    public MediatorMessageBroker(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<TResponse> Send<TRequest, TResponse>(TRequest request,CancellationToken cancellationToken =default)
    {
        if (request is not IRequest<TResponse> mediatrRequest)
        {
            throw new ArgumentException($"Request of type {typeof(TRequest).Name} is not supported.");
        }
        return _mediator.Send(mediatrRequest,cancellationToken);
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
    {
        if (notification is not INotification mediatrNotification)
        {
            throw new ArgumentException($"Notification of type {typeof(TNotification).Name} is not supported.");
        }
        return _mediator.Publish(mediatrNotification,cancellationToken);
    }
}