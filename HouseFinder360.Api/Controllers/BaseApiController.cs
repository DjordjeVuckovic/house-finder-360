using FluentResults;
using HouseFinder360.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult CreateErrorResponse(List<IError> errors)
    {
        var code = 500;
        if (errors.Contains(ErrorResults.BadRequest)) code = 400;
        if (errors.Contains(ErrorResults.InvalidArgument)) code = 400;
        if (errors.Contains(ErrorResults.Forbidden)) code = 403;
        if (errors.Contains(ErrorResults.NotFound)) code = 404;
        if (errors.Contains(ErrorResults.Conflict)) code = 409;
        return Problem(statusCode: code, detail: string.Join(";", errors));
    }
}