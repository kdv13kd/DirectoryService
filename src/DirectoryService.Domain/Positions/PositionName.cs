using CSharpFunctionalExtensions;
using DirectoryService.Domain.Locations;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Positions;

public record PositionName
{
    private PositionName(string value) => Value = value;

    public string Value { get; }

    public static Result<PositionName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < Const.MIN_LENGTH || name.Length > Const.MAX_LENGTH)
        {
            return Result.Failure<PositionName>($"{nameof(LocationName)} должен быть уникальной строкой от {Const.MIN_LENGTH} до {Const.MAX_LENGTH} символов!");
        }

        return Result.Success(new PositionName(name));
    }
}