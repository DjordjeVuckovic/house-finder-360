using HouseFinder360.Api.Requests;
using HouseFinder360.Api.Requests.Auth;
using HouseFinder360.Api.Responses;
using HouseFinder360.Application.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class AuthenticationController:ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("register")]
    [HttpPost]
    public ActionResult<AuthenticationResponse> Register(RegisterRequest registerRequest)
    {
        var result = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.Email,
            registerRequest.Password);
        var authToken = new AuthenticationResponse(result.Token);
        return Ok(authToken);
    }
    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest loginRequest)
    {
        return Ok(loginRequest);
    }
}