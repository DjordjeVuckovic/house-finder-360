using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[ApiController]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult HandleErrors() => Problem();
}