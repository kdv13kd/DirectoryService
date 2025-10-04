using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;
using Const = DirectoryService.Domain.Shared.Constants;

namespace DirectoryService.Domain.Departments;

public record DepartmentIdentifier
{
    private static readonly string _identifierPattern = $@"^[a-z-]{{{Const.MIN_LENGTH},{Const.MAX_LENGTH_SHORT}}}$";

    private DepartmentIdentifier(string value) => Value = value;

    public string Value { get; }

    public static Result<DepartmentIdentifier> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, _identifierPattern))
        {
            return Result.Failure<DepartmentIdentifier>(
                $"{nameof(DepartmentIdentifier)} должен быть строкой от {Const.MIN_LENGTH} до {Const.MAX_LENGTH_SHORT} символов на латинице!");
        }

        return Result.Success(new DepartmentIdentifier(value));
    }
}