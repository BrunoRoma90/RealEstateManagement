
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AgentPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }

    public Agent Agent { get; private set; }

    private AgentPersonalContact() { }

    private AgentPersonalContact(int id,Contact contact, Agent agent):this()
    {
        ValidateAgentPersonalContact(contact, agent);
        Id = id;
        Contact = contact;
        Agent = agent;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private AgentPersonalContact(Contact contact, Agent agent) : this()
    {
        ValidateAgentPersonalContact(contact,agent);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        Agent = Agent.Create(agent.Name, agent.Account,
           agent.Address, agent.EmployeeNumber, agent.AgentNumber,
           agent.AgentPersonalContact, agent.ManagedProperty, agent.AgentAllContact, agent.Manager);
    }

    public static AgentPersonalContact Create(Contact contact, Agent agent)
    {
        return new AgentPersonalContact(contact, agent);
    }

    public static AgentPersonalContact Update(Contact newContact, Agent newAgent)
    {
        return new AgentPersonalContact(newContact, newAgent);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(AgentPersonalContact agentPersonalContact)
    {
        agentPersonalContact.IsDeleted = false;
    }

    private void ValidateAgentPersonalContact(Contact contact, Agent agent)
    {
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


