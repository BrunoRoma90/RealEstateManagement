
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Property : AuditableEntity<int>
{
    public Agent Agent { get; set; }
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

    private Property() { }

    private Property(Agent agent,
        PropertyType propertyType,
        decimal price,
        decimal priceBySquareMeter,
        decimal sizeBySquareMeters,
        string description,
        Address address,
        TransactionType transactionType,
        Availability availability,
        List<Room> rooms, List<PropertyImage> propertyImages):this()
    {
        Agent = agent;
        PropertyType = propertyType;
        Price = price;
        PriceBySquareMeter = priceBySquareMeter;
        SizeBySquareMeters = sizeBySquareMeters;
        Description = description;
        Address = address;
        TransactionType = transactionType;
        Availability = availability;
        Rooms = rooms;
        PropertyImages = propertyImages;
    }
}
