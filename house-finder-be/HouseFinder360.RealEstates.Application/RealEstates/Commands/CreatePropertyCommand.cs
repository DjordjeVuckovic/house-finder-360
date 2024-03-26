using FluentResults;
using HouseFinder360.RealEstates.Application.Common.Dtos.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HouseFinder360.RealEstates.Application.RealEstates.Commands;

public class CreatePropertyCommand : IRequest<Result>
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string RoomsNumber { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
    public string Condition { get; set; } = null!;
    public int Area { get; set; }
    public string Floor { get; set; } = null!;
    public string TotalFloors { get; set; } = null!;
    public int Price { get; set; }
    public string Type { get; set; } = null!;
    public string RegisterStatus { get; set; } = null!;
    public string Heating { get; set; } = null!;
    public int ElevatorsNumber { get; set; }
    public int BalconiesNumber { get; set; }
    public int BathroomsNumber { get; set; }
    public int ToiletsNumber { get; set; }
    public DateTime YearOfBuild { get; set; }
    public IFormFileCollection? Photos { get; set; }
    public Guid UserId { get; set; }
    public string ListingType { get; set; } = null!;
}
