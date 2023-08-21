using FluentResults;

namespace HouseFinder360.Application.Common.Errors;

public class ErrorResult : Error
{
    public ErrorResult(string message,int statusCode) : base(message)
    {
        Metadata.Add(ErrorStatusCodes.LabelName,statusCode);
    }
}