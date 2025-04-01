using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Services.Dtos.Property;

public class RoomDto
{
   
    public RoomType RoomType { get; set; }
    public double Size { get; set; }
}
