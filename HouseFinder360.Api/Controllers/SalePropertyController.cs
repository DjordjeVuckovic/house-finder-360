using HouseFinder360.Api.Requests.Property;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace HouseFinder360.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
//[Authorize]
public class SalePropertyController:ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Content("Hello");
    }

    [HttpPost]
    public IActionResult CreateSaleProperty(SalePropertyRequest salePropertyRequest)
    {
        return Ok(salePropertyRequest);
    }
    
}