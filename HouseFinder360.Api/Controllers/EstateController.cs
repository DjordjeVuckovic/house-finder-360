using Microsoft.AspNetCore.Mvc;
namespace HouseFinder360.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EstateController:ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Content("Hello");
    }
}