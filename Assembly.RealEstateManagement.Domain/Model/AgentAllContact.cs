
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AgentAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public Agent Agent { get; private set; }

    private AgentAllContact() { }

    private AgentAllContact(int id,Name name, Contact contact, Agent agent):this()
    {
        ValidateAgentAllContact(name, contact, agent);
        Id = id;
        Name = name;
        Contact = contact;
        Agent = agent;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private AgentAllContact(Name name, Contact contact, Agent agent)
    {
        ValidateAgentAllContact(name, contact, agent);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        Agent = Agent.Create(agent.Name, agent.Account,
           agent.Address, agent.EmployeeNumber, agent.AgentNumber,
           agent.AgentPersonalContact, agent.ManagedProperty, agent.AgentAllContact, agent.Manager);
    }

    public static AgentAllContact Create(Name name, Contact contact, Agent agent)
    {
        return new AgentAllContact(name, contact, agent);
    }

    private void ValidateAgentAllContact(Name name, Contact contact, Agent agent)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required.");
        }

    }
}


