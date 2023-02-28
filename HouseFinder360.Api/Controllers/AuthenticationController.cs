using HouseFinder360.Api.Requests.Auth;
using HouseFinder360.Api.Responses;
using HouseFinder360.Application.Authentication;
using HouseFinder360.Application.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[Route("api/v1/[controller]")]
public class AuthenticationController:BaseApiController
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
        if (result.IsFailed) return CreateErrorResponse(result.Errors);
        var authToken = new AuthenticationResponse(result.Value.Token);
        return Ok(authToken);   
        
    }
    [Route("login")]
    [HttpPost]
    public IActionResult Login(LoginRequest loginRequest)
    {
        return Ok(loginRequest);
    }
}