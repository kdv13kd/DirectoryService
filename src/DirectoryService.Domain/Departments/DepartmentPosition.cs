namespace DirectoryService.Domain.Departments;

public class DepartmentPosition(Guid id, Guid departmentId, Guid positionId)
{
    public Guid Id => id;

    public Guid DepartmentId => departmentId;

    public Guid LocationId => positionId;
}
