using HouseFinder360.BuildingBlocks.BuildingBlocks;
using HouseFinder360.Domain.Property.ValueObjects;

namespace HouseFinder360.Domain.Property.Entities;

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