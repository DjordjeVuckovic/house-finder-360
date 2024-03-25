using HouseFinder360.Domain.BuildingBlocks.DDD;
using HouseFinder360.RealEstates.Domain.RealEstates.Enums;

namespace HouseFinder360.RealEstates.Domain.RealEstates.Entities;

public sealed class PropertyAction : Entity<int>
{
    public DateTime CreatedAt { get; set; }
    public Guid UserId { get; set; }
    public Guid RealEstateId { get; set; }
    public ActionType ActionType { get; set; }
}
