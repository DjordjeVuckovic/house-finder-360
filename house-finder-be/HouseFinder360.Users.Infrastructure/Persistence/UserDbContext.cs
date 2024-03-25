using System.Reflection;
using HouseFinder360.Users.Infrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseFinder360.Users.Infrastructure.Persistence;

public sealed class UserDbContext : IdentityDbContext<User, UserRole, Guid>
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

    public void SeedRoles()
    {
        const string sql = """
                                   DO $EF$
                                   BEGIN
                                               INSERT INTO users."AspNetRoles" ("Id", "Description", "UserId", "Name", "NormalizedName", "ConcurrencyStamp")
                                               VALUES ('8c5604d7-1036-4262-8c75-5b2d9570b4a0', 'user default role', null, 'user', 'USER', null)
                                               ON CONFLICT("Id") DO NOTHING;
                                               
                                               INSERT INTO users."AspNetRoles" ("Id", "Description", "UserId", "Name", "NormalizedName", "ConcurrencyStamp")
                                               VALUES ('f11a5cff-bc91-4292-9705-b0e41d6b70a3', 'agency role', null, 'agency', 'AGENCY', null)
                                               ON CONFLICT("Id") DO NOTHING;
                           
                                               INSERT INTO users."AspNetRoles" ("Id", "Description", "UserId", "Name", "NormalizedName", "ConcurrencyStamp")
                                               VALUES ('f11a5cff-bc91-4292-9705-b0e41d6b70b3', 'admin default role', null, 'admin', 'ADMIN', null)
                                               ON CONFLICT("Id") DO NOTHING;
                                 END $EF$;
                           """;
        Database.ExecuteSqlRaw(sql);
    }
}
