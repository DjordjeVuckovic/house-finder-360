using System;

namespace HouseFinder360.RealEstates.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTimeOffset UnixTimeNow { get; }
}
