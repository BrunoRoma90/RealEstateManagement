using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    public Client Client { get; private set; }

    private Rating()
    {
        Value = 0;
        Property = Property.CreateProperty
            (default,
            0,
            0,
            0,
            string.Empty,
            Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty),
            default,
            default,
            new List<Room>(),
            new List<PropertyImage>());
        Client = Client.CreateClient
            (Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty),
            Account.Create(string.Empty, string.Empty),
            Contact.CreateContact(default, string.Empty),
            false, new List<FavoriteProperties>(), new List<Rating>(), new List<Comment>(), new List<Visit>());
    }
    private Rating(double value, Property property, Client client) :this()
    {
        ValidateRating(value, property, client);
        Value = value;
        Property = property;
        Client = client;
    }

    private void ValidateRating(double value, Property property, Client client)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Value must be grater than 0");
        }
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client is required.");
        }
    }


    public static Rating CreateComment(double value, Property property, Client client)
    {
        return new Rating(value, property, client);

    }

    public void UpdateRating(double value, Property property, Client client)
    {
        ValidateRating(value, property, client);
        Value = value;
        Property = property;
        Client = client;
    }


}


