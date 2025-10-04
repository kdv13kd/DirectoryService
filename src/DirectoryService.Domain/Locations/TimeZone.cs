using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Locations;

public record TimeZone
{
    private TimeZone(string value) => Value = value;

    public string Value { get; }

    public static Result<TimeZone> Create(string ianaCode)
    {
        if (string.IsNullOrWhiteSpace(ianaCode) || !TimeZoneInfo.TryFindSystemTimeZoneById(ianaCode, out _))
        {
            return Result.Failure<TimeZone>($"{nameof(TimeZone)} должен быть в корректной форме!");
        }

        return Result.Success(new TimeZone(ianaCode));
    }
}