﻿using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Visit : AuditableEntity<int>
{
    public Client Client { get; set; }
    public Property Property { get; private set; }
    public Agent Agent { get; private set; }
    public DateTime VisitDate { get; private set; }
    public string Notes { get; private set; }

    public Visit() { }

    public Visit(Client client, Property property, Agent agent, DateTime visitDate, string notes):this()
    {
        Client = client;
        Property = property;
        Agent = agent;
        VisitDate = visitDate;
        Notes = notes;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }


}




