using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class ManagerService : IManagerService
{
    private readonly IManagerRepository _managerRepository;

    public ManagerService(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }
    //public Agent GetAgent(int id)
    //{
    //    return _managerRepository.GetAgent(id);
    //}

    //public List<Agent> GetAgents()
    //{
    //    return _managerRepository.GetAgents();
    //}

    //public List<Agent> GetAgentsByManagerId(int managerId)
    //{
    //    return _managerRepository.GetAgentsByManagerId(managerId);
    //}


    //public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property)
    //{
    //    _managerRepository.TransferProperty(managerId, fromAgentId, toAgentId, property);
    //}

    //public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId)
    //{
    //    _managerRepository.TransferAllProperties(managerId, fromAgentId, toAgentId);
    //}

    //public List<Visit> GetAgentCalendar(int agentId)
    //{
        
    //    return _managerRepository.GetAgentCalendar(agentId);
    //}

    //public void CreateAppointment(int agentId, Visit visit)
    //{
        
    //    _managerRepository.CreateAppointment(agentId, visit);
    //}

    //public void AddAgent(int managerId, Agent agent)
    //{
    //    _managerRepository.AddAgent(managerId, agent);
    //}

    //public void RemoveAgent(int managerId, Agent agent)
    //{
    //    _managerRepository.RemoveAgent(managerId, agent);
    //}

    //public List<Agent> GetAllManagedAgents(int managerId)
    //{
    //    return _managerRepository.GetAllManagedAgents(managerId);
    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    _managerRepository.AddNotes(visitId, notes);
    //}
}
