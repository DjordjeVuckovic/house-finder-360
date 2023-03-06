using FluentResults;
using FluentValidation;
using HouseFinder360.Application.Common.Errors;
using MediatR;

namespace HouseFinder360.Application.Common.Behaviors;

public class ValidationBehavior<TRequest,TResponse> : 
    IPipelineBehavior<TRequest,TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }
        var validationResults = await _validator.ValidateAsync(request, cancellationToken);
        if (validationResults.IsValid)
        {
            return await next();
        }

        var errors = validationResults.Errors
            .ConvertAll(validationFailure => new ValidationError(validationFailure.ErrorMessage, validationFailure.PropertyName));
        var result = Result.Fail<TResponse>(errors: errors);
        return (dynamic)result;
    }
}