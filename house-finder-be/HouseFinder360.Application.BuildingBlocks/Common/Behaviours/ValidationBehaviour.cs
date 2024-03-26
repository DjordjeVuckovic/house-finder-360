using FluentResults;
using FluentValidation;
using HouseFinder360.Domain.BuildingBlocks.Errors;
using MediatR;

namespace HouseFinder360.Application.BuildingBlocks.Common.Behaviours;

public class ValidationBehaviour<TRequest, TResult>
    : IPipelineBehavior<TRequest, TResult>
    where TRequest : IRequest<TResult>
    where TResult : ResultBase
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors.Select(x => new ErrorResult(
                x.ErrorMessage,
                ErrorStatusCodes.BadRequest)))
            .ToList();

        if (!failures.Any()) return await next();
        return (dynamic)Result.Fail(failures);
    }
}
