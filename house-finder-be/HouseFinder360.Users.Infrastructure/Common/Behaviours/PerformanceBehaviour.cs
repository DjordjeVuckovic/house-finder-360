using System.Diagnostics;
using HouseFinder360.Application.BuildingBlocks.Common;
using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HouseFinder360.Users.Infrastructure.Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;

    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        ICurrentUserService currentUserService)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userEmail = _currentUserService.UserEmail ?? string.Empty;

            _logger.LogWarning("EmployeeManagement Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserEmail} {@Request}",
                requestName, elapsedMilliseconds, userEmail, request);
        }

        return response;
    }
}
