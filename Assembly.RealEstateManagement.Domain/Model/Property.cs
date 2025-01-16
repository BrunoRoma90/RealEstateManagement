
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

    private Property()
    {
        Address = Address.CreateAddress(string.Empty,0, string.Empty, string.Empty, string.Empty);
        Description = string.Empty;
        Rooms = new List<Room>();
        PropertyImages = new List<PropertyImage>();
    }
    private Property(PropertyType propertyType, decimal price, decimal priceBySquareMeter, decimal sizeBySquareMeters,
        string description, Address address, TransactionType transactionType, Availability availability, List<Room> rooms, List<PropertyImage> propertyImages)
    {
        ValidateProperty(propertyType, price, priceBySquareMeter, sizeBySquareMeters, description, address, transactionType, availability, rooms, propertyImages);   
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

    public static Property CreateProperty(PropertyType propertyType, decimal price, decimal priceBySquareMeter, decimal sizeBySquareMeters, string description,
        Address address, TransactionType transactionType, Availability availability, List<Room> rooms, List<PropertyImage> propertyImages)
    {
        return new Property(propertyType, price, priceBySquareMeter, sizeBySquareMeters,
            description, address, transactionType, availability, rooms, propertyImages);
    }

    public void UpdateProperty(Property newProperty)
    {
        ValidateProperty(newProperty.PropertyType, newProperty.Price, newProperty.PriceBySquareMeter, newProperty.SizeBySquareMeters, newProperty.Description,
            newProperty.Address, newProperty.TransactionType, newProperty.Availability, newProperty.Rooms, newProperty.PropertyImages);
        PropertyType = newProperty.PropertyType;
        Price = newProperty.Price;
        PriceBySquareMeter = newProperty.PriceBySquareMeter;
        SizeBySquareMeters= newProperty.SizeBySquareMeters;
        Description = newProperty.Description;
        Address = newProperty.Address;
        TransactionType = newProperty.TransactionType;
        Availability = newProperty.Availability;
        Rooms = newProperty.Rooms;
        PropertyImages = newProperty.PropertyImages;
    }


    public void UpdateAvailability(Availability availability)
    {
        ValidateAvailability(availability);
        Availability = availability;
    }
    private void ValidateAvailability(Availability availability)
    {
        if (availability == default)
        { 
            throw new ArgumentNullException(nameof(availability), "Availability is required."); 
        }
    }

    private void ValidateProperty(PropertyType propertyType, decimal price, decimal priceBySquareMeter, decimal sizeBySquareMeters,
        string description, Address address, TransactionType transactionType, Availability availability, List<Room> rooms, List<PropertyImage> propertyImages)
    {
        
        if(propertyType == default)
        {
            throw new ArgumentNullException(nameof(propertyType), "Property Type is required");
        }
        if(price <= 0)
        {
            throw new ArgumentNullException(nameof(price), "Price must be greater than zero.");
        }
        if (priceBySquareMeter <= 0)
        {
            throw new ArgumentNullException(nameof(priceBySquareMeter), "Price by Square meter must be greater than zero.");
        }
        if (sizeBySquareMeters <= 0)
        {
            throw new ArgumentNullException(nameof(sizeBySquareMeters), "Size by Square meters must be greater than zero.");
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(nameof(description), "Description is required.");
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
        if (transactionType == default)
        {
            throw new ArgumentNullException(nameof(propertyType), "Transaction type is required");
        }
        if (availability == default)
        {
            throw new ArgumentNullException(nameof(availability), "Availability type is required");
        }
        //if (rooms == null || rooms.Count == 0)
        //{ throw new ArgumentNullException(nameof(rooms), "Rooms list is required.");
        //}
        //if (propertyImages == null || propertyImages.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(propertyImages), "PropertyImages list is required.");
        //}

    }

}
