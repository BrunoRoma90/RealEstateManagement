
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Room : AuditableEntity<int>
{
    public RoomType RoomType { get; private set; }
    public double Size { get; private set; }

    private Room() { }
}
