﻿
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AgentPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }

    public Agent Agent { get; private set; }

    private AgentPersonalContact() { }

    private AgentPersonalContact(Contact contact, Agent agent):this()
    {
        Contact = contact;
        Agent = agent;
    }
}


