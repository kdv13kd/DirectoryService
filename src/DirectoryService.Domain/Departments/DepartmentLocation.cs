namespace DirectoryService.Domain.Departments;

public class DepartmentLocation(Guid id, Guid departmentId, Guid locationId)
{
    public Guid Id => id;

    public Guid DepartmentId => departmentId;

    public Guid LocationId => locationId;
}
