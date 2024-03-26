namespace HouseFinder360.Application.BuildingBlocks.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTimeOffset UnixTimeNow { get; }
}
