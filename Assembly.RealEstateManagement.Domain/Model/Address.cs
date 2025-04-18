﻿using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Address : AuditableEntity<int>
{
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string PostalCode { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }

    private Address()
    { }

    private Address(int id,string street, int number, string postalCode, string city, string country):this()
    {
        Id = id;
        Street = street;
        Number = number;
        PostalCode = postalCode;
        City = city;
        Country = country;

    }

    private Address(string street, int number, string postalCode, string city, string country):this()
    {
        ValidateAddress(street, number, postalCode, city, country);
        Street = street;
        Number = number;
        PostalCode = postalCode;
        City = city;
        Country = country;
    }

    public static Address Create(string street, int number, string postalCode, string city, string country)
    {
        return new Address(street,number, postalCode,city,country);
    }

    //public static Address UpdateAddress(int id,string newStreet, int newNumber, string newPostalCode, string newCity, string newCountry)
    //{

    //    return new Address(id,newStreet, newNumber, newPostalCode, newCity, newCountry);

    //}



    public void UpdateAddress(string newStreet, int newNumber, string newPostalCode, string newCity, string newCountry)
    {
        
        Street = newStreet;
        Number = newNumber;
        PostalCode = newPostalCode;
        City = newCity;
        Country = newCountry;
    }



    public static void Restore(Address address)
    {
        address.IsDeleted = false;
    }



    private void ValidateAddress(string street, int number, string postalCode, string city, string country)
    {
        if (string.IsNullOrEmpty(street))
        {
            throw new ArgumentNullException("Street is required.");
        }
        if (number <= 0)
        {
            throw new ArgumentException("Number must be grater than 0");
        }
        if (string.IsNullOrEmpty(postalCode))
        {
            throw new ArgumentNullException("Postal Code is required");
        }
        if (string.IsNullOrEmpty(city))
        {
            throw new ArgumentException("City is required");
        }
        if (string.IsNullOrEmpty(country))
        {
            throw new ArgumentException("Country is required");
        }
    }

    public string GetFormattedAddress()
    {
        return $"{Street}, {Number}, {PostalCode} {City}, {Country}";
    }
}

