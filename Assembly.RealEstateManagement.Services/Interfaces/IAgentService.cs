using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentService
{
    List<Agent> GetAgents();

    public Agent GetAgentById(int id);
    Agent Add(Agent agent);

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
