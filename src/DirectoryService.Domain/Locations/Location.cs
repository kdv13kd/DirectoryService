using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.Locations;

public class Location : Entity<Guid, LocationName>
{
    private Location(
        Guid id,
        LocationName name,
        Address address,
        TimeZone timezone)
        : base(id, name)
    {
        Address = address;
        TimeZone = timezone;
    }

    public Address Address { get; private set; }

    public TimeZone TimeZone { get; private set; }

    public static Result<Location> Create(LocationName name, Address address, TimeZone timezone)
    {
        return Result.Success(new Location(Guid.NewGuid(), name, address, timezone));
    }
}
