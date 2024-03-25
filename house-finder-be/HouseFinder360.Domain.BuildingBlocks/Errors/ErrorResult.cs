using FluentResults;

namespace HouseFinder360.Domain.BuildingBlocks.Errors;

public class ErrorResult : Error
{
    public ErrorResult(string message, int statusCode) : base(message)
    {
        Metadata.Add(ErrorStatusCodes.LabelName, statusCode);
    }
}
