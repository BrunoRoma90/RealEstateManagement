using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Visit : AuditableEntity<int>
{
    public Property Property { get; private set; }
    public Client Client { get; private set; }
    public Agent Agent { get; private set; }
    public DateTime VisitDate { get; private set; }
    public string Notes { get; private set; }

    private Visit()
    {
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
        Agent = Agent.CreateAgent(0,
            Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty),
            Account.Create(string.Empty, string.Empty),
            Contact.CreateContact(default, string.Empty),
            Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty),
            0, 0, new List<Property>(), new List<Visit>(), new List<Contact>(),
            Manager.CreateManager(Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty), Account.Create(string.Empty, string.Empty),
                Contact.CreateContact(default, string.Empty), Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty),
                0, 0, new List<Agent>()));
        VisitDate = DateTime.MinValue;
        Notes = string.Empty;
    }

    private Visit(Property property, Client client, Agent agent, DateTime visitDate, string notes) : this()
    {
        ValidateVisitDate(visitDate);
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
        ValidateVisitDate(visitDate);
        ValidateVisit(property, client, agent, visitDate);
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



    private void ValidateVisitDate(DateTime visitDate)
    {
        foreach (var exitingVisit in Client.Visits)
        {
            if (exitingVisit.VisitDate == visitDate)
            {
                throw new InvalidOperationException("A visit is already scheduled for this time.");
            }
        }
        foreach (var exitingVisit in Agent.Visits)
        {
            if (exitingVisit.VisitDate == visitDate)
            {
                throw new InvalidOperationException("A visit is already scheduled for this time.") ;
            }
        }

    }
}


