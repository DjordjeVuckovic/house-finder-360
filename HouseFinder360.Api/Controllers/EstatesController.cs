using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HouseFinder360.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class EstatesController:ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Content("Hello");
    }
}