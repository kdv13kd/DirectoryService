using CSharpFunctionalExtensions;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Locations;

public record LocationName
{
    private LocationName(string value) => Value = value;

    public string Value { get; }

    public static Result<LocationName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < Const.MIN_LENGTH || name.Length > Const.MAX_LENGTH)
        {
            return Result.Failure<LocationName>(
                $"{nameof(LocationName)} должен быть уникальной строкой от {Const.MIN_LENGTH} до {Const.MAX_LENGTH} символов!");
        }

        return Result.Success(new LocationName(name));
    }
}