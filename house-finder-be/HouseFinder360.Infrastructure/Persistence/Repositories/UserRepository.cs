using HouseFinder360.Application.Common.Interfaces.Persistence;
using HouseFinder360.Domain.Users;
using HouseFinder360.Infrastructure.Persistence.Generic;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Infrastructure.Persistence.Repositories;

public class UserRepository: Repository<User,Guid>,IUserRepository
{
    public UserRepository(HouseFinder360DbContext dbContext) : base(dbContext)
    {
    }
    
    public  async Task<User?> GetUserByEmail(string email)
    {
        return  await DbSet.SingleOrDefaultAsync(user => user.Email == email);
    }
    
}