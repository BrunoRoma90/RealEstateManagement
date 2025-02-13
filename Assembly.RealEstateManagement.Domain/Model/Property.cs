﻿
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
        Created = DateTime.Now;
        Updated = DateTime.Now;
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
