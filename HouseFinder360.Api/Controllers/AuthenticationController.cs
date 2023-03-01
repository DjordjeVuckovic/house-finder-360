using HouseFinder360.Api.Requests.Auth;
using HouseFinder360.Api.Responses;
using HouseFinder360.Application.Authentication;
using HouseFinder360.Application.Authentication.Commands.Register;
using HouseFinder360.Application.Authentication.Query.Login;
using HouseFinder360.Application.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HouseFinder360.Api.Controllers;
[Route("api/v1/[controller]")]
public class AuthenticationController:BaseApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    
    [HttpPost("register")]
    public async Task<ActionResult<AuthenticationResponse>> Register([FromBody] RegisterRequest registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);
        var authResult = await _sender.Send(command);
        
        if (authResult.IsFailed) return CreateErrorResponse(authResult.Errors);
        var authToken = _mapper.Map<AuthenticationResponse>(authResult.Value);
        return Ok(authToken);   
        
    }
    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] LoginRequest loginRequest)
    {
        var query = _mapper.Map<LoginQuery>(loginRequest);
        var loginResult = await _sender.Send(query);
        return Ok(loginRequest);
    }
}