using HouseFinder360.RealEstates.Domain.RealEstates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseFinder360.RealEstates.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<RealEstate>
{
    public void Configure(EntityTypeBuilder<RealEstate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description)
            .HasMaxLength(200);
        builder.Property(x => x.Title)
            .HasMaxLength(100);
        builder.HasIndex(x => x.UserId);
        builder.OwnsOne(saleProperty => saleProperty.Price,
            pb =>
        {
            pb.Property(x => x.Value)
                .HasColumnName("Price");
        });

        builder.OwnsOne(x => x.FloorInformation, fi =>
        {
            fi.Property(x => x.TotalFloors)
                .HasColumnName("TotalFloors")
                .HasMaxLength(20);
            fi.Property(x => x.Floor)
                .HasColumnName("Floor")
                .HasMaxLength(20);
        });

        builder.OwnsOne(x => x.PropertyType, pt =>
        {
            pt.Property(x => x.PropertyTypeDeclaration)
                .HasColumnName("PropertyTypeDeclaration")
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.Area, a =>
        {
            a.Property(x => x.SquadMeter).HasColumnName("Area");
        });

        builder.OwnsOne(x => x.AdditionalInfo);
        builder
            .HasOne(x => x.Address)
            .WithMany();

        builder
            .HasMany(x => x.Actions)
            .WithOne()
            .HasForeignKey(x => x.RealEstateId);

        builder.Ignore(x => x.TotalClicks);

        builder.Ignore(x => x.TotalLikes);
    }
}
