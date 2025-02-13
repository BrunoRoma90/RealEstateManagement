
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AgentPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }

    public Agent Agent { get; private set; }

    private AgentPersonalContact() { }

    private AgentPersonalContact(Contact contact, Agent agent):this()
    {
        ValidateAgentPersonalContact(contact, agent);
        Contact = contact;
        Agent = agent;
        Created = DateTime.Now;
        Updated = DateTime.Now;
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


