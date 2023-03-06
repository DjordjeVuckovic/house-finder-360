using FluentResults;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseFinder360.Api.Controllers;
[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult CreateErrorResponse(List<IError> errors)
    {
        const int statusCode = 400;
        foreach (var error in errors.OfType<ErrorMessage>())
        {
            return Problem(statusCode: (int) error.StatusCode, detail: error.Message,title: nameof(error));
        }
        return Problem(statusCode: statusCode, detail: string.Join(";", errors),title: string.Join(";", errors));
    }

    private ActionResult MapValidationProblem(List<IError> errors)
    {
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
        return Problem();
    }
}