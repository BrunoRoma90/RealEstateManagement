using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Dtos.Property;

public class PropertyDto
{
    public int Id { get; set; }
    public AgentDto Agent { get; set; }
    public PropertyType PropertyType { get; set; }
    public decimal Price { get; set; }
    public decimal PriceBySquareMeter { get; set; }
    public decimal SizeBySquareMeters { get; set; }
    public string Description { get; set; }
    public AddressDto Address { get; set; }
    public TransactionType TransactionType { get; set; }
    public Availability Availability { get; set; }
    public List<RoomDto> Rooms { get; set; }
    public List<PropertyImageDto> PropertyImages { get; set; }
}
