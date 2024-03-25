using FluentResults;

namespace HouseFinder360.Domain.BuildingBlocks.Common.Enums;

public static class EnumUtil
{
    public static Result<T> ToEnum<T>(string value)
    {
        try
        {
            var result = (T)Enum.Parse(typeof(T), value, true);
            return result;
        }
        catch
        {
            return Result.Fail($"Cannot parse {typeof(T)} with value {value} ");
        }
    }
    public static Result<string> FromEnum<T>(T enumParse)
        where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            return Result.Fail($"Type {typeof(T)} is not an enum.");
        }

        try
        {
            var result = Enum.GetName(typeof(T), enumParse);
            return result is null ? Result.Fail("Cannot parse value") : result!;
        }
        catch
        {
            return Result.Fail($"Cannot parse {typeof(T)} with value {enumParse} ");
        }
    }
}
