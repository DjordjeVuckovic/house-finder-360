using HouseFinder360.Domain.Common.BuildingBlocks;

namespace HouseFinder360.Domain.Property.Entities;

public class Address : Entity<long>
{
    public string Street { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public Address(long id, string street, string streetNumber, string city, string country) : base(id)
    {
        Street = street;
        StreetNumber = streetNumber;
        City = city;
        Country = country;
    }
}