
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Room : AuditableEntity<int>
{
    public RoomType RoomType { get; private set; }
    public double Size { get; private set; }
  

    private Room()
    {
        RoomType = default;
        Size = 0;
        

    }
    private Room(RoomType roomType, double size)
    {
        ValidateRoom(roomType, size);
        RoomType = roomType;
        Size = size;
     
    }

    public static Room CreateRoom(Room room) 
    {
        return new Room(room.RoomType, room.Size);
    }
    
    public void UpdateRoom(Room newRoom)
    {
        ValidateRoom(newRoom.RoomType, newRoom.Size);
        RoomType = newRoom.RoomType;
        Size = newRoom.Size;

    }

    private void ValidateRoom(RoomType roomType, double size)
    {
    
        if(roomType == default)
        {
            throw new ArgumentNullException(nameof(roomType), "Room Type is required");
        }
        if (size <= 0) 
        {
            throw new ArgumentNullException(nameof(size), "Size must be greater than zero.");
        }
        
        
    }
}
