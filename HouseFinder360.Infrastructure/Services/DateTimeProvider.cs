using HouseFinder360.Application.Common.Interfaces.Services;

namespace HouseFinder360.Infrastructure.Services;

public class DateTimeProvider:IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}