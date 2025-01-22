using Assembly.RealEstateManagement.Domain.Common;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperties : AuditableEntity<int>
{
    public Client Client { get; private set; }
    public Property Property { get; private set; }

    private FavoriteProperties()
    {
        Client = Client.CreateClient(Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty),
            Account.Create(string.Empty, string.Empty),
            Contact.CreateContact(default, string.Empty),
            false, new List<FavoriteProperties>(), new List<Rating>(), new List<Comment>());
        Property = Property.CreateProperty(default,
            0,
            0,
            0,
            string.Empty,
            Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty),
            default,
            default,
            new List<Room>(),
            new List<PropertyImage>());
    }

    private FavoriteProperties(Client client, Property property) : this()
    {
        ValidateFavoriteProperties(client, property);
        Client = client;
        Property = property;
    }

    private void ValidateFavoriteProperties(Client client, Property property)
    {

        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client is required.");
        }

    }

    public static FavoriteProperties CreateFavoriteProperties(Client client,Property property)
    {
        return new FavoriteProperties(client, property);

    }

    public void UpdateFavoriteProperties(Client client, Property property)
    {
        ValidateFavoriteProperties(client, property);
        Property = property;
        Client = client;
    }

}
