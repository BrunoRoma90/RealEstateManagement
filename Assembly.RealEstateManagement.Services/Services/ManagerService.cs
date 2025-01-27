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
    public Agent GetAgent(int id)
    {
        return _managerRepository.GetAgent(id);
    }

    public List<Agent> GetAgents()
    {
        return _managerRepository.GetAgents();
    }

    public List<Agent> GetAgentsByManagerId(int managerId)
    {
        return _managerRepository.GetAgentsByManagerId(managerId);
    }
}
