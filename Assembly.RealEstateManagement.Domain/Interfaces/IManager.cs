using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Interfaces;

public interface IManager
{
    public int ManagerNumber { get; }
    public List<Agent> ManagedAgents { get; }
    void AddAgent(Agent agent);
    void RemoveAgent(Agent agent);
    void ReassignSingleProperty(Property property, Agent fromAgent, Agent toAgent);
    void ReassignAllProperties(Agent fromAgent, Agent toAgent);
    List<Visit> GetAgentCalendar(Agent agent);
    void CreateAppointment(Agent agent, Visit visit);
    List<Agent> GetAllManagedAgents();
    void UpdateManager(Manager manager);
}

