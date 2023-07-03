using Carter;
using HouseFinder360.Api.Dto.Requests.Auth;
using HouseFinder360.Api.Dto.Responses;
using HouseFinder360.Api.Utils;
using HouseFinder360.Application.Authentication.Commands.Register;
using HouseFinder360.Application.Authentication.Query.Login;
using MapsterMapper;
using MediatR;

namespace HouseFinder360.Api.Endpoints;

public class UsersModule : CarterModule
{
    public UsersModule() : base("/api/v1/auth")
    {
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (RegisterRequest registerRequest,ISender sender,IMapper mapper) =>
        {
            var command = mapper.Map<RegisterCommand>(registerRequest);
            var authResult = await sender.Send(command);
        
            if (authResult.IsFailed) return Results.BadRequest(authResult.Errors.ToResponse());
            var authToken = mapper.Map<AuthenticationResponse>(authResult.Value);
            return Results.Ok(authToken);
        });
        app.MapPost("", async (LoginRequest loginRequest, ISender sender, IMapper mapper) =>
        {
            var query = mapper.Map<LoginQuery>(loginRequest);
            var loginResult = await sender.Send(query);
            return loginResult.IsFailed 
                ? Results.BadRequest(loginResult.Errors.ToResponse()) 
                : Results.Ok(loginResult);
        });
    }
}