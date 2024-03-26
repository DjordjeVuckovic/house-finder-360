using HouseFinder360.RealEstates.Domain.RealEstates.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseFinder360.RealEstates.Infrastructure.Persistence.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(a => a.Id);
        builder.OwnsOne(a => a.City, city =>
        {
            city.Property(c => c.Name).HasColumnName("CityName").HasMaxLength(50);
            city.Property(c => c.Longitude).HasColumnName("CityLongitude");
            city.Property(c => c.Latitude).HasColumnName("CityLatitude");
        });
        builder.OwnsOne(x => x.Street, country =>
        {
            country.Property(c => c.Name).HasColumnName("StreetName").HasMaxLength(50);
            country.Property(c => c.Longitude).HasColumnName("StreetLongitude");
            country.Property(c => c.Latitude).HasColumnName("StreetLatitude");
        });
    }
}
