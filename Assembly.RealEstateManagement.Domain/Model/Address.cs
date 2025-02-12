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
}

