using CSharpFunctionalExtensions;

namespace DirectoryService.Domain.Departments;

public record DepartmentPath
{
    private DepartmentPath(string value) => Value = value;

    public string Value { get; }

    public static Result<DepartmentPath> Create(DepartmentIdentifier currentIdentifier, Department? parent)
    {
        var path = parent is not null
            ? $"{parent.Path.Value}.{currentIdentifier.Value}"
            : currentIdentifier.Value;

        return Result.Success(new DepartmentPath(path));
    }
}