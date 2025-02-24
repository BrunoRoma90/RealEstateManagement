
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentService : IAgentService
{
    private IAgentRepository _agentRepository;

    public AgentService(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public Agent GetAgentById(int id)
    {
        var agent = _agentRepository.GetById(id);
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }
        return agent;
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public Agent Add(Agent agent) 
    {
        return _agentRepository.Add(agent);

    }

    //public void AddVisitToMyList(int agentId, Visit visit)
    //{

    //    _agentRepository.AddVisitToMyList(agentId,visit);

    //}

    //public void RemoveVisitToMyList(int agentId, Visit visit)
    //{
    //    _agentRepository.RemoveVisitToMyList(agentId, visit);   
    //}

    //public List<Visit> GetAllVisits(int agentId)
    //{
    //    if (agentId <= 0)
    //    {
    //        throw new ArgumentException("Agent ID must be greater than zero.", nameof(agentId));
    //    }

        
    //    return _agentRepository.GetVisitsByAgentId(agentId);
    //}

    //public void MarkAvailabilityProperty(Property property, Availability availability, Agent agent)
    //{
    //    if (property == null)
    //    {
    //        throw new ArgumentNullException(nameof(property), "Property cannot be null.");
    //    }
    //    bool existingProperty = false;
    //    foreach (var managedProperty in agent.ManagedProperties)
    //    {
    //        if (managedProperty.Id == property.Id)
    //        {
    //            managedProperty.UpdateAvailability(availability);
    //            existingProperty = true;
    //            break;
    //        }
    //    }
    //    if (!existingProperty)
    //    {
    //        {
    //            throw new InvalidOperationException("Property cannot be updated because it is not managed by this agent.");
    //        }
    //    }

    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    _agentRepository.AddNotes(visitId, notes);
    //}

    //public void AddContactToMyList(int angentId, Contact contact)
    //{
    //    _agentRepository.AddContactToMyList(angentId, contact);
    //}
    //public void RemoveContactToMyList(int agentId, Contact contact)
    //{
    //    _agentRepository.RemoveContactFromMyList(agentId, contact);
    //}

    //public List<Contact> GetMyContacts(int agentId)
    //{
    //    return _agentRepository.GetMyContacts(agentId);
    //}


    //public void AddPropertyToAgent(int agentId, Property property)
    //{
        
    //    _agentRepository.AddPropertyToMyList(agentId, property);
    //}

    //public void RemovePropertyFromAgent(int agentId, Property property)
    //{
    //    _agentRepository.RemovePropertyFromAgent(agentId, property);
    //}

  
}
