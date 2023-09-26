using FluentResults;
using HouseFinder360.Users.Infrastructure.Errors;
using HouseFinder360.Users.Infrastructure.Model;
using HouseFinder360.Users.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Users.Infrastructure.Features.Users.Queries;

public class GetByEmailQueryHandler : IRequestHandler<GetByEmailQuery,Result<User>>
{
    private readonly UserDbContext _dbContext;

    public GetByEmailQueryHandler(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<User>> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .SingleOrDefaultAsync(user => user.Email == request.Email,cancellationToken);
        if (user is null)
        {
            return Result.Fail(UsersErrors.WrongCredential);
        }

        return user;
    }
}
public record GetByEmailQuery(string Email) : IRequest<Result<User>>;