
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerRepository : IRepository<Manager, int>
{
    public List<Agent> GetAgents();

    public Agent GetAgent(int id);

    public List<Agent> GetAgentsByManagerId(int managerId);

    public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property);

    public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId);


    public List<Visit> GetAgentCalendar(int agentId);
    public void CreateAppointment(int agentId, Visit visit);

    public void AddAgent(int managerId, Agent agent);

    public void RemoveAgent(int managerId, Agent agent);

    public List<Agent> GetAllManagedAgents(int managerId);

    public void AddNotes(int visitId, string notes);

}
