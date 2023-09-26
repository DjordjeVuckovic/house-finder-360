using HouseFinder360.Application.BuildingBlocks.Common.Interfaces;

namespace HouseFinder360.Api.Services;

public class DateTimeProvider: IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
    public DateTimeOffset UnixTimeNow => DateTimeOffset.UtcNow;
}