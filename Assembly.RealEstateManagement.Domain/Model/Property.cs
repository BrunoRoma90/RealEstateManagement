
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;
using System.Runtime.Loader;

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

    private Property(int id,Agent agent,
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
        Id = id;
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


    private Property( Agent agent,
        PropertyType propertyType,
        decimal price,
        decimal priceBySquareMeter,
        decimal sizeBySquareMeters,
        string description,
        Address address,
        TransactionType transactionType,
        Availability availability,
        List<Room> rooms, List<PropertyImage> propertyImages) : this()
    {
        ValidateProperty(agent, propertyType, price, priceBySquareMeter, sizeBySquareMeters, description, address, transactionType, availability, rooms, propertyImages);
        Agent = agent;
        PropertyType = propertyType;
        Price = price;
        PriceBySquareMeter = priceBySquareMeter;
        SizeBySquareMeters = sizeBySquareMeters;
        Description = description;
        Address = Address.Create(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        TransactionType = transactionType;
        Availability = availability;
        Rooms = rooms;
        PropertyImages = propertyImages;
     
    }

    public static Property Create(Agent agent, PropertyType propertyType,decimal price,decimal priceBySquareMeter,decimal sizeBySquareMeters,
        string description,Address address,TransactionType transactionType,Availability availability,List<Room> rooms, List<PropertyImage> propertyImages)
    {
        return new Property(agent, propertyType, price, priceBySquareMeter, sizeBySquareMeters, description,
            address, transactionType, availability, rooms, propertyImages);
    }

    //public static Property Update(Agent newAgent, PropertyType newPropertyType, decimal newPrice, decimal newPriceBySquareMeter, decimal newSizeBySquareMeters,
    //    string newDescription, Address newAddress, TransactionType newTransactionType, Availability newAvailability, List<Room> newRooms, List<PropertyImage> newPropertyImages)
    //{
    //    return new Property(newAgent, newPropertyType, newPrice, newPriceBySquareMeter, newSizeBySquareMeters, newDescription,
    //        newAddress, newTransactionType, newAvailability, newRooms, newPropertyImages);
    //}

    public void Update(int id,Agent newAgent, PropertyType newPropertyType, decimal newPrice, decimal newPriceBySquareMeter, decimal newSizeBySquareMeters,
       string newDescription, Address newAddress, TransactionType newTransactionType, Availability newAvailability, List<Room> newRooms, List<PropertyImage> newPropertyImages)
    {
        Id = id;
        Agent = newAgent;
        PropertyType = newPropertyType;
        Price = newPrice;
        PriceBySquareMeter = newPriceBySquareMeter;
        SizeBySquareMeters = newSizeBySquareMeters;
        Description = newDescription;
        Address = newAddress;
        TransactionType = newTransactionType;
        Availability = newAvailability;
        Rooms = newRooms;
        PropertyImages = newPropertyImages;
    }

    public static void Restore(Property property)
    {
        property.IsDeleted = false;
    }

    public void AddRoom(Room room)
    {
        if (room == null)
            throw new ArgumentNullException(nameof(room), "Room cannot be null.");

        Rooms.Add(room);
    }

   
    public void AddPropertyImage(PropertyImage propertyImage)
    {
        if (propertyImage == null)
            throw new ArgumentNullException(nameof(propertyImage), "Property Image cannot be null.");

        PropertyImages.Add(propertyImage);
    }



    private void ValidateProperty(Agent agent, PropertyType propertyType, decimal price, decimal priceBySquareMeter,
        decimal sizeBySquareMeters, string description, Address address, TransactionType transactionType,
        Availability availability, List<Room> rooms, List<PropertyImage> propertyImages)
    {

        if (agent == null)
        {
            throw new ArgumentException(nameof(agent), "Agent is required.");
        }
        if (!Enum.IsDefined(typeof(PropertyType), propertyType))
        {
            throw new ArgumentException("Property type.");
        }
        if (price <= 0)
        {
            throw new ArgumentException(nameof(price), "Price  must be greater than zero.");
        }
        if (priceBySquareMeter <= 0)
        {
            throw new ArgumentException(nameof(priceBySquareMeter), "Price By Square Meter must be greater than zero.");
        }
        if (sizeBySquareMeters <= 0)
        {
            throw new ArgumentException(nameof(sizeBySquareMeters), "Size By Square Meters must be greater than zero.");
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException("Descripton name is required");
        }
        if (address == null)
        {
            throw new ArgumentException(nameof(address), "Address is required.");
        }
        if (!Enum.IsDefined(typeof(TransactionType), transactionType))
        {
            throw new ArgumentException("Transaction type.");
        }
        if (!Enum.IsDefined(typeof(Availability), availability))
        {
            throw new ArgumentException("Availability type.");
        }
        if (rooms == null || rooms.Count == 0)
        {
            throw new ArgumentNullException(nameof(rooms), "Rooms list is required.");
        }
        if (propertyImages == null || propertyImages.Count == 0)
        {
            throw new ArgumentNullException(nameof(propertyImages), "Property Images list is required.");
        }
    }
}
