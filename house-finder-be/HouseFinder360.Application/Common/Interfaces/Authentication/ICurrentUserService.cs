namespace HouseFinder360.Application.Common.Interfaces.Authentication;

public interface ICurrentUserService
{
    public string? UserEmail { get; }
}