using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Contact Contact { get; private set; }

    protected Person()
    {
        Name = null;
        Account = null;
        Contact = null;
    }
    protected Person(Name name, Account account, Contact contact)
    {
        Name = name;
        Account = account;
        Contact = contact;
    }


}

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    public Client Client { get; private set; }

    private Rating()
    {
        Value = 0;
        Property = null;
        Client = null;
    }
    private Rating(double value, Property property, Client client)
    {
        Value = value;
        Property = property;
        Client = client;
    }
}

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }
    public Client Client { get; private set; }

    private Comment()
    {
        Text = string.Empty;
        Property = null;
        Client = null;
    }
    private Comment(string text, Property property, Client client)
    {
        Text = text;
        Property = property;
        Client = client;
    }
}

public class FavoriteProperties : AuditableEntity<int>
{
    public Client Client { get; private set; }
    public Property Property { get; private set; }

    private FavoriteProperties() 
    {
        Client = null;
        Property = null;
    }

    private FavoriteProperties(Client client, Property property)
    {
        Client = client;
        Property = property;
    }
}


