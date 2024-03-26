using HouseFinder360.Domain.BuildingBlocks.DDD;
using HouseFinder360.RealEstates.Domain.RealEstates.ValueObjects;

namespace HouseFinder360.RealEstates.Domain.RealEstates.Entities;

public class Address : Entity<long>
{
    public Location Street { get; private set; } = null!;
    public Location City { get; private set; } = null!;
    public string Country { get; private set; } = null!;


    public Address(
        Location street,
        Location city,
        string country)
    {
        Street = street;
        City = city;
        Country = country;
    }

    private Address()
    {
    }
}
