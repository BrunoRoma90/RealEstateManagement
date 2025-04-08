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

    public ManagerDto GetManagerById(int id)
    {
        var manager = _unitOfWork.ManagerRepository.GetById(id);
        var account = _unitOfWork.ManagerRepository.GetManagerAccount(id);
        var address = _unitOfWork.ManagerRepository.GetManagerAddress(id);
        if (manager is null)
        {
            throw new KeyNotFoundException($"Manager with ID {id} not found.");
        }
        if (account is null)
        {
            throw new KeyNotFoundException($"Manager account with ID {id} not found.");
        }
        if (address is null)
        {
            throw new KeyNotFoundException($"Manager address with ID {id} not found.");
        }
        return new ManagerDto 
        {
            EmployeeNumber = manager.EmployeeNumber,
            ManagerNumber = manager.ManagerNumber,
            FirstName = manager.Name.FirstName,
            LastName = manager.Name.LastName,
            Email = manager.Account.Email,
            Address = new AddressDto
            {
                Street = manager.Address.Street,
                Number = manager.Address.Number,
                PostalCode = manager.Address.PostalCode,
                City = manager.Address.City,
                Country = manager.Address.Country,

            }
        };
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


    public ManagerDto Update(UpdateManagerDto managerDto)
    {
        var existingManager = _unitOfWork.ManagerRepository.GetById(managerDto.Id);
        if (existingManager == null)
            throw new ArgumentNullException(nameof(existingManager), "Manager not found.");

        var address = Address.UpdateAddress(
            existingManager.Address.Id,
            managerDto.Address?.Street ?? existingManager.Address.Street,
            managerDto.Address?.Number ?? existingManager.Address.Number,
            managerDto.Address?.PostalCode ?? existingManager.Address.PostalCode,
            managerDto.Address?.City ?? existingManager.Address.City,
            managerDto.Address?.Country ?? existingManager.Address.Country
        );

        var account = Account.Update(
            existingManager.Account.Id,
            managerDto.Email ?? existingManager.Account.Email,
            managerDto.Password ?? existingManager.Account.Password
        );

        var name = Name.Create(
            managerDto.FirstName ?? existingManager.Name.FirstName,
            managerDto.MiddleNames?.Any() == true ? managerDto.MiddleNames : existingManager.Name.MiddleNames,
            managerDto.LastName ?? existingManager.Name.LastName
        );

        var updatedManager = Manager.Update(
            existingManager.Id,
            managerDto.EmployeeNumber != 0 ? managerDto.EmployeeNumber : existingManager.EmployeeNumber,
            name,
            account,
            address,
            managerDto.ManagerNumber != 0 ? managerDto.ManagerNumber : existingManager.ManagerNumber,
            existingManager.ManagerAllContacts,
            existingManager.ManagerPersonalContact,
            existingManager.ManagedAgents
        );

        using (_unitOfWork)
        {
            var result = _unitOfWork.ManagerRepository.Update(updatedManager);
            _unitOfWork.Commit();

            return new ManagerDto
            {
                Id = result.Id,
                EmployeeNumber = result.EmployeeNumber,
                FirstName = result.Name.FirstName,
                LastName = result.Name.LastName,
                Email = result.Account.Email,
                Address = new AddressDto
                {
                    Street = result.Address.Street,
                    Number = result.Address.Number,
                    PostalCode = result.Address.PostalCode,
                    City = result.Address.City,
                    Country = result.Address.Country,
                },
                ManagerNumber = result.ManagerNumber,
            };
        }
    }





    //public ManagerDto Update(UpdateManagerDto managerDto)
    //{
    //    var existingManager = _unitOfWork.ManagerRepository.GetById(managerDto.Id);
    //    if (existingManager == null)
    //        throw new ArgumentNullException(nameof(existingManager), "Manager not found.");




    //    using (_unitOfWork)
    //    {
    //        _unitOfWork.BeginTransaction();


    //        var updatedManager = Manager.Update(
    //            managerDto.Id,
    //            managerDto.EmployeeNumber != 0 ? managerDto.EmployeeNumber : existingManager.EmployeeNumber,
    //            managerDto.ManagerNumber != 0 ? managerDto.ManagerNumber : existingManager.ManagerNumber,
    //            existingManager.ManagerAllContacts,
    //            existingManager.ManagerPersonalContact,
    //            existingManager.ManagedAgents
    //        );

    //        _unitOfWork.ManagerRepository.Update(updatedManager);
    //        _unitOfWork.Commit();
    //    }

    //    return new ManagerDto
    //    {
    //        Id = existingManager.Id,
    //        EmployeeNumber = existingManager.EmployeeNumber,
    //        FirstName = existingManager.Name.FirstName,
    //        LastName = existingManager.Name.LastName,
    //        Email = existingManager.Account.Email,
    //        Address = new AddressDto
    //        {
    //            Street = existingManager.Address.Street,
    //            Number = existingManager.Address.Number,
    //            PostalCode = existingManager.Address.PostalCode,
    //            City = existingManager.Address.City,
    //            Country = existingManager.Address.Country,
    //        },
    //        ManagerNumber = existingManager.ManagerNumber,
    //    };
    //}



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
