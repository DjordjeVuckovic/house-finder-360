using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Domain.Entities;

namespace HouseFinder360.Infrastructure.Persistence;

public class UserRepository:IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }
}