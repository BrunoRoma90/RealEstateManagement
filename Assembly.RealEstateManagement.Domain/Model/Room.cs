using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Room : AuditableEntity<int>
{
    public RoomType RoomType { get; private set; }
    public double Size { get; private set; }
    public string Description { get; private set; }

    private Room()
    {
        RoomType = default;
        Size = 0;
        Description = string.Empty;

    }
    private Room(RoomType roomType, double size, string description)
    {
        RoomType = roomType;
        Size = size;
        Description = description;
    }
}
