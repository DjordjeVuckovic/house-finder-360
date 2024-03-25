using Microsoft.AspNetCore.Identity;

namespace HouseFinder360.Users.Infrastructure.Model;

public class UserRole : IdentityRole<Guid>
{
    public string Description { get; set; } = string.Empty;
}
