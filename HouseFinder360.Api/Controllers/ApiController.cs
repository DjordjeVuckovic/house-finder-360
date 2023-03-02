using FluentResults;
using HouseFinder360.Api.Responses;
using HouseFinder360.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseFinder360.Api.Controllers;
[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult CreateErrorResponse(List<IError> errors)
    {
        const int statusCode = 400;
        var listErrors = errors.OfType<ValidationError>().ToList();
        if (listErrors.Count == errors.Count)
        {
            var modelStateDictionary = new ModelStateDictionary();
            foreach (var error in listErrors)
            {
                modelStateDictionary.AddModelError(error.StatusCode.ToString(),error.Message);
            }

            return ValidationProblem(modelStateDictionary);
        }
        foreach (var error in errors.OfType<ErrorMessage>())
        {
            return Problem(statusCode: (int) error.StatusCode, detail: error.Message,title: nameof(error));
        }
        return Problem(statusCode: statusCode, detail: string.Join(";", errors),title: string.Join(";", errors));
    }

    private static ErrorResponse MapGenericErrors(List<IError> errors)
    {
        var code = 500;
        if (errors.Contains(ErrorResults.Generic.BadRequest)) code = 400;
        if (errors.Contains(ErrorResults.Generic.InvalidArgument)) code = 400;
        if (errors.Contains(ErrorResults.Generic.Forbidden)) code = 403;
        if (errors.Contains(ErrorResults.Generic.NotFound)) code = 404;
        if (errors.Contains(ErrorResults.Generic.Conflict)) code = 409;
        return new ErrorResponse
        {
            StatusCode = code,
        };
    }

}