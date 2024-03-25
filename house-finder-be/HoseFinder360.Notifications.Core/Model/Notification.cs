using HouseFinder360.Domain.BuildingBlocks.DDD;

namespace HoseFinder360.Notifications.Core.Model;

public class Notification : Entity<int>
{
    public string Content { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public bool Seen { get; private set; }
}
