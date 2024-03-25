using FluentResults;
using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HouseFinder360.Application.BuildingBlocks.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehaviour(
        ILogger<LoggingBehaviour<TRequest, TResponse>> logger,
        ICurrentUserService currentUserService)
    {
        _logger = logger;
        _currentUserService = currentUserService;
    }
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userEmail = _currentUserService.UserEmail ?? string.Empty;
        _logger.LogInformation("Starting request: {@Name}, {@userEmail}, {@DateTimeUtc}",
            requestName,
            userEmail,
            DateTime.UtcNow);
        var result = await next();
        if (result.IsFailed)
        {
            _logger.LogError("Request failure: {@Name}, {@userEmail},{@Errors}, {@DateTimeUtc}",
                requestName,
                userEmail,
                result.Errors,
                DateTime.UtcNow);
        }
        _logger.LogInformation("Completed request: {@Name}, {@userEmail}, {@DateTimeUtc}",
            requestName,
            userEmail,
            DateTime.UtcNow);
        return result;
    }
}
