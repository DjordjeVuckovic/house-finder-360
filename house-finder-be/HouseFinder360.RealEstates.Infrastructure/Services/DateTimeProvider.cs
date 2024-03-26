using System;
using HouseFinder360.RealEstates.Application.Common.Interfaces.Services;

namespace HouseFinder360.RealEstates.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
    public DateTimeOffset UnixTimeNow => DateTimeOffset.UtcNow;
}
