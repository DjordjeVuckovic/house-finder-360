using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.Entities;

public class Address : Entity<long>
{
    public string Street { get; private set; }
    public string StreetNumber { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }

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