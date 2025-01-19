using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Address : AuditableEntity<int>
{
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string PostalCode { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }


    private Address()
    {
        Street = string.Empty;
        Number = 0;
        PostalCode = string.Empty;
        City = string.Empty;
        Country = string.Empty;
    }

    private Address(string street, int number, string postalCode, string city, string country) :this()
    {
        ValidateAddress(street, number, postalCode, city, country);
        Street = street;
        Number = number;
        PostalCode = postalCode;
        City = city;
        Country = country;
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

    public Address WithUpdatedStreet(string street)
    {
        return new Address(street, Number, PostalCode, City, Country);
    }

    public Address WithUpdatedNumber(int number) 
    {
        return new Address(Street, number, PostalCode, City, Country);
    }
    public Address WithUpdatedPostalCode(string postalCode)
    {
        return new Address(Street, Number, postalCode, City, Country);
    }

    public Address WithUpdatedCity(string city)
    { 
        return new Address(Street, Number, PostalCode, city, Country);
    }
    public Address WithUpdatedCountry(string country)
    {
        return new Address(Street, Number, PostalCode, City, country);
    }

    public static Address CreateAddress(string street, int number, string postalCode, string city, string country)
    {
        return new Address(street, number, postalCode, city, country);
    }

    public void UpdateAddress(string street, int number, string postalCode, string city, string country)
    {
        ValidateAddress(street, number, postalCode, city, country);
        Street = street;
        Number = number;
        PostalCode = postalCode;
        City = city;
        Country = country;
    }
}

