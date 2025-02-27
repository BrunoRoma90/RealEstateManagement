using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Visit : AuditableEntity<int>
{
    public Client Client { get; private set; }
    public Property Property { get; private set; }
    public Agent Agent { get; private set; }
    public DateTime VisitDate { get; private set; }
    public string Notes { get; private set; }

    private Visit() { }

    private Visit(int id, Client client, Property property, Agent agent, DateTime visitDate, string notes):this()
    {
        Client = client;
        Property = property;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;

    }

    private Visit(Client client, Property property, Agent agent, DateTime visitDate, string notes) : this()
    {
        ValidateVisit(property, client, agent, visitDate);
        Client = Client.Create(client.Name, client.Account, client.Address, client.FavoriteProperties, client.Ratings, client.Comments);
        Property = Property.Create(property.Agent, property.PropertyType, property.Price, property.PriceBySquareMeter, property.SizeBySquareMeters,
            property.Description, property.Address, property.TransactionType, property.Availability, property.Rooms, property.PropertyImages);
        Agent = Agent.Create(agent.Name, agent.Account, agent.Address, agent.AgentNumber, agent.EmployeeNumber, agent.AgentPersonalContact, agent.ManagedProperty,
            agent.AgentAllContact, agent.Manager);
        VisitDate = visitDate;
        Notes = notes;
    }

    public static Visit Create(Client client, Property property, Agent agent, DateTime visitDate, string notes)
    {
        return new Visit(client, property, agent, visitDate, notes);
    }

    public static Visit Update(Client newClient, Property newProperty, Agent newAgent, DateTime newVisitDate, string newNotes)
    {
        return new Visit(newClient, newProperty, newAgent, newVisitDate, newNotes);
    }



    public static void Restore(Visit visit)
    {
        visit.IsDeleted = false;
    }
    private void ValidateVisit(Property property, Client client, Agent agent, DateTime visitDate)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), " Property is required");
        }
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client is required");
        }
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required");
        }

        if (visitDate == DateTime.MinValue)
        {
            throw new InvalidOperationException("Visit date is required");
        }
    }


}




