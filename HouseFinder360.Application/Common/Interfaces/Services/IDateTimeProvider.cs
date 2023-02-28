using System;

namespace HouseFinder360.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
  DateTime UtcNow { get; }  
}