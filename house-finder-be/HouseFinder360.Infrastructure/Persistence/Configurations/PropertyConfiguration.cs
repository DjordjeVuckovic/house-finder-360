using HouseFinder360.Domain.Property;
using HouseFinder360.Domain.Property.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseFinder360.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Description)
            .HasMaxLength(200);
        builder.Property(sp => sp.Title)
            .HasMaxLength(100);
        builder.OwnsOne(saleProperty => saleProperty.Price, 
            pb =>
        {
            pb.Property(x => x.Value)
                .HasColumnName("Price");
        });
        builder.OwnsOne(sp => sp.FloorInformation, fi =>
        {
            fi.Property(x => x.TotalFloors).HasColumnName("TotalFloors").HasMaxLength(20);
            fi.Property(x => x.Floor).HasColumnName("Floor").HasMaxLength(20);
        });
        builder.OwnsOne(sp => sp.PropertyType, pt =>
        {
            pt.Property(x => x.PropertyTypeDeclaration).HasColumnName("PropertyTypeDeclaration").HasMaxLength(50);
        });
        builder.OwnsOne(sp => sp.Area, a =>
        {
            a.Property(x => x.SquadMeter).HasColumnName("Area");
        });
        builder.OwnsOne(sp => sp.AdditionalInfo);
        builder.HasOne(sp => sp.Address)
            .WithMany();
    }
}