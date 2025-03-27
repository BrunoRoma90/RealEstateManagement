using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class ManagerService : IManagerService
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public ManagerDto Add(CreateManagerDto manager)
    {
        _unitOfWork.BeginTransaction();

        Manager managerToAdd = Manager.Create(
        manager.EmployeeNumber,
        Name.Create(manager.FirstName, manager.MiddleNames, manager.LastName),
        Account.Create(manager.Email, manager.Password),
        Address.Create(manager.Address.Street, manager.Address.Number, manager.Address.PostalCode, manager.Address.City, manager.Address.Country),
        manager.ManagerNumber,
        new List<ManagerAllContact>(),
        new List<ManagerPersonalContact>(),
        new List<Agent>()
         );

        Manager addedManager;
        using (_unitOfWork) 
        {
            addedManager = _unitOfWork.ManagerRepository.Add(managerToAdd);
            _unitOfWork.Commit();

        }

        var managerDto = new ManagerDto
        {

            EmployeeNumber = addedManager.EmployeeNumber,
            ManagerNumber = addedManager.ManagerNumber,
            FirstName = addedManager.Name.FirstName,
            LastName = addedManager.Name.LastName,
            Email = addedManager.Account.Email,
            Address = new AddressDto
            {
                Street = addedManager.Address.Street,
                Number = addedManager.Address.Number,
                PostalCode = addedManager.Address.PostalCode,
                City = addedManager.Address.City,
                Country = addedManager.Address.Country,

            }


        };



        return managerDto;
    }

    public Manager GetManagerById(int id)
    {
        var manager = _unitOfWork.ManagerRepository.GetById(id);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {id} not found.");
        }
        return manager;
    }

    public IEnumerable<ManagerDto> GetManagers()
    {
        var managers = new List<Manager>();

        managers = _unitOfWork.ManagerRepository.GetAllManagersWithAccount();
        managers = _unitOfWork.ManagerRepository.GetAllManagersWithAddress();

        return managers.Select(x => new ManagerDto 
        {
            
            EmployeeNumber = x.EmployeeNumber,
            ManagerNumber = x.ManagerNumber,
            FirstName = x.Name.FirstName,
            LastName = x.Name.LastName, 
            Email = x.Account.Email,
            Address = new AddressDto 
            {
                Street = x.Address.Street,
                Number = x.Address.Number,
                PostalCode = x.Address.PostalCode,
                City = x.Address.City,
                Country= x.Address.Country,
            }

        }).ToList();
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
