
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Room : AuditableEntity<int>
{
    public RoomType RoomType { get; private set; }
    public double Size { get; private set; }

    private Room() { }

    private Room(int id,RoomType roomType, double size):this()
    {
        ValidateRoom(roomType, size);
        Id = id;
        RoomType = roomType;
        Size = size;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private Room(RoomType roomType, double size) : this()
    {
        ValidateRoom(roomType, size);
        RoomType = roomType;
        Size = size;
        
    }

    public static Room Create(RoomType roomType, double size)
    {
        return new Room(roomType, size);
    }

    public static Room Update(RoomType newRoomType, double newSize)
    {
        return new Room(newRoomType, newSize);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(Room room)
    {
        room.IsDeleted = false;
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
