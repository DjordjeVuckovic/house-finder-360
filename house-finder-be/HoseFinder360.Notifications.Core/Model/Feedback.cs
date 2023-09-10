using HouseFinder360.Domain.BuildingBlocks.DDD;

namespace HoseFinder360.Notifications.Core.Model;

public class Feedback : Entity<int>
{
    public Guid UserId { get; set; }
    public string Comment { get; set; } = null!;
}