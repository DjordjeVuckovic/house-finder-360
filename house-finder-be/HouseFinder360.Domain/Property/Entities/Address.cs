using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.Entities;

public class Address : Entity<long>
{
    public string Street { get; private set; } = null!;
    public string StreetNumber { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Country { get; private set; } = null!;

    public Address(long id, string street, string streetNumber, string city, string country) : base(id)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        Country = country;
    }

    private Address()
    {
    }
}