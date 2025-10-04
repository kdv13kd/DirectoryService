using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Departments;

public class Department : Entity<Guid, DepartmentName>
{
    private List<Department> _children = [];
    private List<DepartmentLocation> _departmentLocations = [];
    private List<DepartmentPosition> _departmentPositions = [];

    private Department(
        Guid id,
        DepartmentName name,
        DepartmentIdentifier identifier,
        Department? parent,
        DepartmentPath path,
        short depth,
        IEnumerable<DepartmentLocation> departmentLocations,
        IEnumerable<DepartmentPosition> departmentPositions)
        : base(id, name)
    {
        Identifier = identifier;
        Parent = parent;
        Path = path;
        Depth = depth;
        Parent = parent;
        _departmentLocations = departmentLocations.ToList();
        _departmentPositions = departmentPositions.ToList();
    }

    public DepartmentIdentifier Identifier { get; private set; }

    public Department? Parent { get; private set; }

    public Guid? ParentId => Parent != null ? Parent.Id : default;

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public IReadOnlyList<Department> Children => _children;

    public IReadOnlyList<DepartmentLocation> DepartmentLocations => _departmentLocations;

    public IReadOnlyList<DepartmentPosition> DepartmentPositions => _departmentPositions;

    public void AddChild(Department department) => _children.Add(department);

    public void AddChild(DepartmentLocation departmentLocation) => _departmentLocations.Add(departmentLocation);

    public void AddChild(DepartmentPosition departmentPosition) => _departmentPositions.Add(departmentPosition);

    public static Result<Department> Create(
        DepartmentName name,
        DepartmentIdentifier identifier,
        Department? parent,
        DepartmentPath path,
        IEnumerable<DepartmentLocation> departmentLocations,
        IEnumerable<DepartmentPosition> departmentPositions)
    {
        var depth = (short)(parent is not null ? parent.Depth + 1 : 1);

        if (departmentLocations is null || !departmentLocations.Any())
        {
            return Result.Failure<Department>($"{nameof(DepartmentLocations)} не должен быть пустым!");
        }

        if (departmentPositions is null || !departmentPositions.Any())
        {
            return Result.Failure<Department>($"{nameof(DepartmentPositions)} не должен быть пустым!");
        }

        var department = new Department(
            Guid.NewGuid(), name, identifier, parent, path, depth, departmentLocations, departmentPositions);

        if (department?.Parent is not null)
        {
            department.Parent.AddChild(department);
        }

        return Result.Success(department!);
    }
}
