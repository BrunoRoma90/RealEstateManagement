
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
        Name = name;
        Contact = contact;
        Agent = agent;
    }
}


