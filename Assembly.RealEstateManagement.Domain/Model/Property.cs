using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Property : AuditableEntity<int>
{
    public PropertyType PropertyType { get; private set; }
    public decimal Price { get; private set; }
    public decimal PriceBySquareMeter { get; private set; }

    public decimal SizeBySquareMeters { get; private set; }

    public string Description { get; private set; }
    public Address Address { get; private set; }
    public TransactionType TransactionType { get; private set; }
    public Availability Availability { get; private set; }
    public List<Room> Rooms { get; private set; }
    public List<PropertyImage> PropertyImages { get; private set; }

}
