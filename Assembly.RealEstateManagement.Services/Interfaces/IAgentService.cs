﻿using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentService
{
    IEnumerable<AgentDto> GetAgents();

    public AgentDto GetAgentById(int id);
    AgentDto Add(CreateAgentDto agent);

    AgentDto Update(UpdateAgentDto agent);

    //public void AddVisitToMyList(int agentId, Visit visit);
    //public void RemoveVisitToMyList(int agentId, Visit visit);
    //List<Visit> GetAllVisits(int agentId);

    //public List<Contact> GetMyContacts(int agentId);

    //public void AddNotes(int visitId, string notes);

    //public void AddContactToMyList(int angentId, Contact contact);

    //public void RemoveContactToMyList(int agentId, Contact contact);

    //public void AddPropertyToAgent(int agentId, Property property);

    //public void RemovePropertyFromAgent(int agentId, Property property);
}
