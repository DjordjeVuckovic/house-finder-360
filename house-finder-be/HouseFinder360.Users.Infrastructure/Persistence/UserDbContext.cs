using System.Reflection;
using HouseFinder360.Users.Infrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Users.Infrastructure.Persistence;

public sealed class UserDbContext : IdentityDbContext<User,UserRole, Guid>
{
    
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.HasDefaultSchema(Schema.UsersSchema);
        base.OnModelCreating(builder);
    }
}