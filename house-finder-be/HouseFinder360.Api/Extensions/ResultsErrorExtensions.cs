using FluentResults;
using HouseFinder360.Application.Common.Errors;

namespace HouseFinder360.Api.Extensions;

public static class ResultsErrorExtensions
{
    public static ErrorResponse ToResponse(this IEnumerable<IError> errorResults)
    {
        return new ErrorResponse
        {
            Errors = errorResults.Select(x => x.Message)
        };
    }
    public static IResult BuildErrorResponse(this IEnumerable<IError> errors)
    {
        const int defaultCode = 409;
        var errorsList = errors.ToList();
        var firstErrorWithCode = errorsList
            .FirstOrDefault(err => err.Metadata.TryGetValue(ErrorStatusCodes.LabelName, out _));
        var code = firstErrorWithCode?.Metadata[ErrorStatusCodes.LabelName] ?? defaultCode;
        var errorResponse = errorsList.ToResponse();
        return code switch
        {
            ErrorStatusCodes.BadRequest => Results.BadRequest(errorResponse),
            ErrorStatusCodes.NotFound => Results.NotFound(errorResponse),
            _ => Results.Conflict(errorResponse)
        };
    }
}
public class ErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}
