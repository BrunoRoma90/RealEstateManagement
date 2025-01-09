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

public abstract class Employee : Person
{

    public int EmployeeNumber { get; private set; }
    public Address Address { get; private set; }

    private Employee(Name name, Account account, Contact contact, Address address) : base(name, account, contact)
    {

        Address = address;

    }
}

public class Client : Person
{
    public bool IsRegisted { get; private set; }
    public List<FavoriteProperties> FavoriteProperties { get; private set; }

    public List<Rating> Ratings { get; private set; }

    public List<Comment> Comments { get; private set; }

   private Client()
    {
        
        IsRegisted = false;
        FavoriteProperties = new List<FavoriteProperties>();
        Ratings = new List<Rating>(); 
        Comments = new List<Comment>(); 
    }

    private Client(Name name, Account account, Contact contact, bool isRegisted,
        List<FavoriteProperties> favoriteProperties, List<Rating> ratings, List<Comment> comments)
        : base(name, account, contact)
    {
        IsRegisted = isRegisted;
        FavoriteProperties = favoriteProperties;
        Ratings = ratings;
        Comments = comments;
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

public class Agent : Employee
{

}
public class Manager : Employee
{

}

public class AdministrativeUsers
{

}
public class Admin
{

}


