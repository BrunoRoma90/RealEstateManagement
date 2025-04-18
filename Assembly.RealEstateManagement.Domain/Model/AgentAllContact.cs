﻿
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

    }

    private AgentAllContact(Name name, Contact contact, Agent agent)
    {
        ValidateAgentAllContact(name, contact, agent);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        Agent = agent;
    }

    public static AgentAllContact Create(Name name, Contact contact, Agent agent)
    {
        return new AgentAllContact(name, contact, agent);
    }

    public void Update(int id, Name newName, Contact newContact)
    {
        Id = id;
        Name = newName;
        Contact = newContact;
    }

    //public static AgentAllContact Update(Name newName, Contact newContact, Agent newAgent)
    //{
    //    return new AgentAllContact(newName, newContact, newAgent);
    //}


    public static void Restore(AgentAllContact agentAllContact)
    {
        agentAllContact.IsDeleted = false;
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


