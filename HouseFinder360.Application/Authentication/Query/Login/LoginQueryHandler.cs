using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using MediatR;

namespace HouseFinder360.Application.Authentication.Query.Login;

public class LoginQueryHandler: IRequestHandler<LoginQuery, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var user =  _userRepository.GetUserByEmail(query.Email);
        if (user is null)
        {
            return Result.Fail<AuthResult>(ApplicationErrors.Generic.BadRequest);
        }

        if (user.Password != query.Password)
        {
            
        }
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, user.FirstName, user.LastName,user.Email);
        return Result.Fail<AuthResult>(ApplicationErrors.Generic.BadRequest);
        //return new AuthResult(token);
    }
}