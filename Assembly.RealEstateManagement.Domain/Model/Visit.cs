namespace Assembly.RealEstateManagement.Domain.Model;

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


