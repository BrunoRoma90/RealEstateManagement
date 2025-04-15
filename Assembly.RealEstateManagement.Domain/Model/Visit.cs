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
        ValidateVisit(property, client, agent, visitDate);
        Id = id; 
        Client = client;
        Property = property;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;

    }

    private Visit(Client client, Property property, Agent agent, DateTime visitDate, string notes) : this()
    {
        ValidateVisit(property, client, agent, visitDate);
        Client = client;
        Property = property;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;
    }

    public static Visit Create(Client client, Property property, Agent agent, DateTime visitDate, string notes)
    {
        return new Visit(client, property, agent, visitDate, notes);
    }

    //public static Visit Update(Client newClient, Property newProperty, Agent newAgent, DateTime newVisitDate, string newNotes)
    //{
    //    return new Visit(newClient, newProperty, newAgent, newVisitDate, newNotes);
    //}

    public void Update(int id,Client newClient, Property newProperty, Agent newAgent, DateTime newVisitDate, string newNotes)
    {
        ValidateVisit(newProperty, newClient, newAgent, newVisitDate); 
        Id = id;
        Client = newClient;
        Property = newProperty;
        Agent = newAgent;
        VisitDate = newVisitDate;
        Notes = newNotes;

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




