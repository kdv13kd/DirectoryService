namespace DirectoryService.Domain.Shared;

public abstract class Entity<TId, TName>
    where TId : notnull
    where TName : notnull
{

    protected Entity(TId id, TName name)
    {
        Id = id;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public TId Id { get; }

    public TName Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}
