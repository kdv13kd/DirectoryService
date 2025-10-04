using CSharpFunctionalExtensions;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Departments;

public record DepartmentName
{
    private DepartmentName(string value) => Value = value;

    public string Value { get; }

    public static Result<DepartmentName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < Const.MIN_LENGTH || value.Length > Const.MAX_LENGTH)
        {
            return Result.Failure<DepartmentName>(
                $"{nameof(DepartmentName)} должен быть строкой от {Const.MIN_LENGTH} до {Const.MAX_LENGTH} символов!");
        }

        return Result.Success(new DepartmentName(value));
    }
}