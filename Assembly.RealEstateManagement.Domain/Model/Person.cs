using System.Data;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Xml.Linq;
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
public class Visit
{
    public Property Property { get; private set; }
    public Client Client { get; private set; }
    public Agent Agent { get; private set; }
    public DateTime VisitDate { get; private set; }
    public string Notes { get; private set; }

    private Visit() 
    {
       
        VisitDate = DateTime.MinValue;
        Notes = string.Empty;
    }

    private Visit(Property property, Client client, Agent agent, DateTime visitDate, string notes)
    {
        ValidateVisit(property, client, agent, visitDate);
        Property = property;
        Client = client;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;
    }

    public static Visit CreateVisit(Property property, Client client, Agent agent, DateTime visitDate, string notes)
    {
        return new Visit(property, client, agent, visitDate, notes);
    }
    public void UpdateVisit(Property property, Client client, Agent agent, DateTime visitDate, string notes)
    {
        ValidateVisit(property,client, agent, visitDate);
        Property = property;
        Client = client;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;

    }
    private void ValidateVisit(Property property, Client client, Agent agent, DateTime visitDate)
    {
        if (property == null) 
        {
            throw new ArgumentNullException(nameof(property) ," Property is required");
        }
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client is required");
        }
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required");
        }

        if(visitDate == DateTime.MinValue)
        {
            throw new InvalidOperationException("Visit date is required");
        }
    }
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


