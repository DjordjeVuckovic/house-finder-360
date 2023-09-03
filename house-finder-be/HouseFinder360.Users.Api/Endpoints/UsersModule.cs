using HouseFinder360.Users.Api.Dto.Requests;
using HouseFinder360.Users.Api.Dto.Responses;
using HouseFinder360.Users.Api.Extensions;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Commands.Register;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Query.Login;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace HouseFinder360.Users.Api.Endpoints;

internal static class UsersModule
{

    public static void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/v1/auth/register", async (RegisterRequest registerRequest,ISender sender,IMapper mapper) =>
        {
            var command = mapper.Map<RegisterCommand>(registerRequest);
            var authResult = await sender.Send(command);
        
            if (authResult.IsFailed) return authResult.Errors.BuildErrorResponse();
            var authToken = mapper.Map<AuthenticationResponse>(authResult.Value);
            return Results.Ok(authToken);
        });
        app.MapPost("/api/v1/auth", async (LoginRequest loginRequest, ISender sender, IMapper mapper) =>
        {
            var query = mapper.Map<LoginQuery>(loginRequest);
            var loginResult = await sender.Send(query);
            return loginResult.IsFailed 
                ? loginResult.Errors.BuildErrorResponse()
                : Results.Ok(loginResult.Value);
        });
    }
}