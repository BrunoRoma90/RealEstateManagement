using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerRepository : Repository<Manager, int>, IManagerRepository
{
    public ManagerRepository(ApplicationDbContext context) : base(context)
    {

    }

    public void AddAgent(int managerId, Agent agent)
    {
        throw new NotImplementedException();
    }

    public void AddNotes(int visitId, string notes)
    {
        throw new NotImplementedException();
    }

    public void CreateAppointment(int agentId, Visit visit)
    {
        throw new NotImplementedException();
    }

    public Agent GetAgent(int id)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAgentCalendar(int agentId)
    {
        throw new NotImplementedException();
    }

    public List<Agent> GetAgents()
    {
        throw new NotImplementedException();
    }

    public List<Agent> GetAgentsByManagerId(int managerId)
    {
        throw new NotImplementedException();
    }

    public List<Agent> GetAllManagedAgents(int managerId)
    {
        throw new NotImplementedException();
    }

    public void RemoveAgent(int managerId, Agent agent)
    {
        throw new NotImplementedException();
    }

    public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId)
    {
        throw new NotImplementedException();
    }

    public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property)
    {
        throw new NotImplementedException();
    }
}
