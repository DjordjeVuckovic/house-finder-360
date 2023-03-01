using FluentResults;
using HouseFinder360.Api.Responses;
using HouseFinder360.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult CreateErrorResponse(List<IError> errors)
    {
        var result = MapGenericErrors(errors);
        return Problem(statusCode: result.StatusCode, detail: string.Join(";", errors));
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
    private static ErrorResponse MapUserErrors(List<IError> errors)
    {
        var code = 500;
        if (errors.Contains(ErrorResults.User.DuplicateEmail)) code = 400;
        return new ErrorResponse
        {
            StatusCode = code
        };
    }
    
}