using HouseFinder360.RealEstates.Application.Common.Dtos.Shared;

namespace HouseFinder360.RealEstates.Application.RealEstates.Dto;

public class PropertyResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Price { get; set; }
    public AddressDto Address { get; set; } = null!;
    public string BedroomsNumber { get; set; } = null!;
    public int BathroomsNumber { get; set; }
    public int Area { get; set; }
    public string PropertyType { get; set; } = null!;
    public string Purpose { get; set; } = null!;
    public string? Description { get; set; }
    public IEnumerable<string> PropertyImageUris { get; set; } = null!;
}