using HouseFinder360.Domain.Property;
using HouseFinder360.Domain.Property.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseFinder360.Infrastructure.Persistence.Configurations;

public class SalePropertyConfiguration : IEntityTypeConfiguration<SaleProperty>
{
    public void Configure(EntityTypeBuilder<SaleProperty> builder)
    {
        builder.ToTable("SaleProperty");
        builder.HasKey(sp => sp.Id);
        builder.Property(sp => sp.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value,
                value => SalePropertyId.CreateUnique());
        builder.Property(sp => sp.Description)
            .HasMaxLength(500);
        builder.Property(sp => sp.Title)
            .HasMaxLength(100);
        builder.OwnsOne(saleProperty => saleProperty.Price, 
            pb =>
        {
            pb.Property(x => x.Value)
                .HasColumnName("Price");
        });
        builder.OwnsOne(sp => sp.FloorInformation);
        builder.OwnsOne(sp => sp.PropertyType);
        builder.OwnsOne(sp => sp.Price);
        builder.OwnsOne(sp => sp.Area);
        builder.HasOne(sp => sp.Address)
            .WithMany();
        builder.HasOne(sp => sp.AdditionalInfo).WithOne()
            .HasForeignKey<PropertyAdditionalInfo>(info => info.PropertyId);
    }
}