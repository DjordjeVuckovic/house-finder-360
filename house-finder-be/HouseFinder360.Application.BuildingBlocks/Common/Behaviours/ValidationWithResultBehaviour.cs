using FluentResults;
using FluentValidation;
using HouseFinder360.Domain.BuildingBlocks.Errors;
using MediatR;

namespace HouseFinder360.Application.BuildingBlocks.Common.Behaviours;

public class ValidationWithResultBehaviour<TRequest, TResult> : IPipelineBehavior<TRequest, Result<TResult>>
    where TRequest : notnull
    where TResult : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationWithResultBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<Result<TResult>> Handle(
        TRequest request,
        RequestHandlerDelegate<Result<TResult>> next,
        CancellationToken cancellationToken)
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
        return Result.Fail<TResult>(failures);
    }
}
