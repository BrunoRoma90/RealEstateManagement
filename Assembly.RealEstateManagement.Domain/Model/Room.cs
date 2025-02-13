
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Room : AuditableEntity<int>
{
    public RoomType RoomType { get; private set; }
    public double Size { get; private set; }

    private Room() { }

    private Room(RoomType roomType, double size):this()
    {
        RoomType = roomType;
        Size = size;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private void ValidateRoom(RoomType roomType, double size)
    {
        if (!Enum.IsDefined(typeof(RoomType), roomType))
        {
            throw new ArgumentException("Room type.");
        }
        if (size <= 0)
        {
            throw new ArgumentException(nameof(size), "Size must be greater than zero.");
        }
    }
}
