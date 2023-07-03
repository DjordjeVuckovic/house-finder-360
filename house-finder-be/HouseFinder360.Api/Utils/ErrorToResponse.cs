using FluentResults;

namespace HouseFinder360.Api.Utils;

public class ErrorResponse
{
    public string? Error { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}

public static class ErrorToResponse
{
    public static ErrorResponse ToResponse(this IEnumerable<IError> errorResults)
    {
        var enumerable = errorResults as IError[] ?? errorResults.ToArray();
        return new ErrorResponse
        {
            Error = enumerable.Select(x => x.Message).SingleOrDefault(),
            Errors = enumerable.Select(x => x.Message)
        };
    }
}