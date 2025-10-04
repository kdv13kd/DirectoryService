using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departments;
using DirectoryService.Domain.Shared;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Positions;

public class Position : Entity<Guid, PositionName>
{
    private Position(Guid id, PositionName name, string? description)
        : base(id, name) => Description = description;

    public string? Description { get; private set; }

    public List<Department> Departments { get; set; } = [];

    public static Result<Position> Create(PositionName name, string? description)
    {
        if (description is not null && description.Length > Const.MAX_LENGTH_LARGE)
        {
            return Result.Failure<Position>(
                $"{nameof(Description)} не должен превышать {Const.MAX_LENGTH_LARGE} символов!");
        }

        return Result.Success(new Position(Guid.NewGuid(), name, description!));
    }
}
