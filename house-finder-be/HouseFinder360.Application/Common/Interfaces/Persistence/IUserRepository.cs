using HouseFinder360.Application.Common.Interfaces.Persistence.Generic;
using HouseFinder360.Domain.User;

namespace HouseFinder360.Application.Common.Interfaces.Persistence;

public interface IUserRepository : IRepository<User,Guid>
{
    Task<User?> GetUserByEmail(string email);
}