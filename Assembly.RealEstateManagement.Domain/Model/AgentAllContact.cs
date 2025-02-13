
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AgentAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public Agent Agent { get; private set; }

    private AgentAllContact() { }

    private AgentAllContact(Name name, Contact contact, Agent agent):this()
    {
        ValidateAgentAllContact(name, contact, agent);
        Name = name;
        Contact = contact;
        Agent = agent;
        Created = DateTime.Now;
        Updated = DateTime.Now;
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


