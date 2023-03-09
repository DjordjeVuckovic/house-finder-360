using FluentResults;
using HouseFinder360.Application.Authentication.Common;
using HouseFinder360.Application.Common.Errors;
using HouseFinder360.Application.Common.Interfaces.Authentication;
using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.User;
using MediatR;

namespace HouseFinder360.Application.Authentication.Commands.Register;

public class RegisterCommandHandler: IRequestHandler<RegisterCommand, Result<AuthResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AuthResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userByEmail = await _userRepository.GetUserByEmail(request.Email);
        if (userByEmail is not null)
        {
            var error = Result.Fail<AuthResult>(ApplicationErrors.Generic.BadRequest);
            return error;
        }
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, request.FirstName, request.LastName, request.Email);
        var user = new User(userId, request.FirstName, request.LastName, request.Email, request.Password,
            UserRole.Buyer);
        await _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);
        return new AuthResult(token);
    }
}