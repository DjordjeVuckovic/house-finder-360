using FluentResults;
using HouseFinder360.Users.Infrastructure.Features.Authentication.Common;
using MediatR;

namespace HouseFinder360.Users.Infrastructure.Features.Authentication.Query.Login;

public record LoginQuery(
    string EmailOrPhone,
    string Password) : IRequest<Result<AuthResult>>;
