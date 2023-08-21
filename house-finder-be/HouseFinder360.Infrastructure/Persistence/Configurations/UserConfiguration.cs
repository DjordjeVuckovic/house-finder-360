using HouseFinder360.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseFinder360.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(user => user.Email).HasMaxLength(50);
        builder.Property(user => user.FirstName).HasMaxLength(70);
        builder.Property(user => user.LastName).HasMaxLength(70);
        builder.Property(user => user.Phone).HasMaxLength(20);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Phone).IsUnique();
        
    }
}