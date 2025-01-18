using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }
    public Client Client { get; private set; }

    private Comment()
    {
        Text = string.Empty;
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
            false, new List<FavoriteProperties>(), new List<Rating>(), new List<Comment>());
    }
    private Comment(string text, Property property, Client client) : this()
    {   ValidateComment(text, property, client);
        Text = text;
        Property = property;
        Client = client;
    }

    private void ValidateComment(string text, Property property, Client client)
    { 
        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Text is required.", nameof(text));
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


    public static Comment CreateComment(string text, Property property, Client client)
    {
        return new Comment(text, property, client);

    }

    public void UpdateComment(string text, Property property, Client client) 
    {
        ValidateComment(text, property, client);
        Text = text;
        Property = property;
        Client = client;
    }
    public Comment WithUpdatedText(string text)
    {
        return new Comment(text, Property, Client);
    }

    public string GetFormattedComment()
    {
        return $"{Text} (Property: {Property.Id}, Client: {Client.Id})";
    }
}


