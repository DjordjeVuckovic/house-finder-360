using HouseFinder360.Domain.Entities;

namespace HouseFinder360.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}