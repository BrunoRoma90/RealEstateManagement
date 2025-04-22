using Assembly.RealEstateManagement.Domain.Core;
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
            Id = id,
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
            Id = x.Id,
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
        manager.Email,
        manager.Password,
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



    public ManagerDto Update(UpdateManagerDto manager)
    {
        var existingManager = _unitOfWork.ManagerRepository.GetById(manager.Id);
        var existingAddress = _unitOfWork.ManagerRepository.GetManagerAddress(manager.Id);
        var existingAccount = _unitOfWork.ManagerRepository.GetManagerAccount(manager.Id);

        if (existingManager is null)
            throw new KeyNotFoundException("Manager not found.");

        if (existingAccount is null)
            throw new KeyNotFoundException("Manager account not found.");

        if (existingAddress is null)
            throw new KeyNotFoundException("Manager address not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;

            existingManager.Name.Update(
                IsValidString(manager.FirstName, existingManager.Name.FirstName),
                IsValidArray(manager.MiddleNames, existingManager.Name.MiddleNames),
                IsValidString(manager.LastName, existingManager.Name.LastName));

            existingManager.Account.Update(
                IsValidString(manager.Email, existingManager.Account.Email),
                manager.Password ?? string.Empty);

            existingManager.Address.UpdateAddress(
                IsValidString(manager.Address?.Street, existingManager.Address.Street),
                manager.Address?.Number == 0 ? existingManager.Address.Number : manager.Address.Number,
                IsValidString(manager.Address?.PostalCode, existingManager.Address.PostalCode),
                IsValidString(manager.Address?.City, existingManager.Address.City),
                IsValidString(manager.Address?.Country, existingManager.Address.Country)
            );


            existingManager.Update(
                existingManager.Id,
                manager.EmployeeNumber == 0 ? existingManager.EmployeeNumber : manager.EmployeeNumber,
                existingManager.Name,
                IsValidString(manager.Email, existingManager.Account.Email),
                manager.Password ?? string.Empty,
                existingManager.Address,
                manager.ManagerNumber == 0 ? existingManager.ManagerNumber : manager.ManagerNumber,
                new List<ManagerAllContact>(),
                new List<ManagerPersonalContact>(),
                new List<Agent>()
            );


            _unitOfWork.ManagerRepository.Update(existingManager);
            _unitOfWork.Commit();


            var managerDto = new ManagerDto
            {
                Id = existingManager.Id,
                EmployeeNumber = existingManager.EmployeeNumber,
                ManagerNumber = existingManager.ManagerNumber,
                FirstName = existingManager.Name.FirstName,
                LastName = existingManager.Name.LastName,
                Email = existingManager.Account.Email,
                Address = new AddressDto
                {
                    Street = existingManager.Address.Street,
                    Number = existingManager.Address.Number,
                    PostalCode = existingManager.Address.PostalCode,
                    City = existingManager.Address.City,
                    Country = existingManager.Address.Country
                }
            };

            return managerDto;
        }
    }


    //public ManagerDto Update(UpdateManagerDto manager)
    //{
    //    var existingManager = _unitOfWork.ManagerRepository.GetById(manager.Id);
    //    var existingAddress = _unitOfWork.ManagerRepository.GetManagerAddress(manager.Id);
    //    var existingAccount = _unitOfWork.ManagerRepository.GetManagerAccount(manager.Id);

    //    if (existingManager is null)
    //        throw new KeyNotFoundException("Manager not found.");

    //    if (existingAccount is null)
    //        throw new KeyNotFoundException("Manager account not found.");

    //    if (existingAddress is null)
    //        throw new KeyNotFoundException("Manager address not found.");

    //    using (_unitOfWork)
    //    {
    //        _unitOfWork.BeginTransaction();


    //        existingManager.Name.Update(
    //            string.IsNullOrWhiteSpace(manager.FirstName) ? existingManager.Name.FirstName : manager.FirstName,
    //            manager.MiddleNames == null || manager.MiddleNames.Length == 0 ? existingManager.Name.MiddleNames : manager.MiddleNames,
    //            string.IsNullOrWhiteSpace(manager.LastName) ? existingManager.Name.LastName : manager.LastName);

    //        existingManager.Account.Update(
    //            string.IsNullOrWhiteSpace(manager.Email) ? existingManager.Account.Email : manager.Email,
    //            string.IsNullOrWhiteSpace(manager.Password) ? existingManager.Account.Password : manager.Password);

    //        existingManager.Address.UpdateAddress(
    //            string.IsNullOrWhiteSpace(manager.Address.Street) ? existingManager.Address.Street : manager.Address.Street,
    //            manager.Address.Number == 0 ? existingManager.Address.Number : manager.Address.Number,
    //            string.IsNullOrWhiteSpace(manager.Address.PostalCode) ? existingManager.Address.PostalCode : manager.Address.PostalCode,
    //            string.IsNullOrWhiteSpace(manager.Address.City) ? existingManager.Address.City : manager.Address.City,
    //            string.IsNullOrWhiteSpace(manager.Address.Country) ? existingManager.Address.Country : manager.Address.Country
    //        );


    //        existingManager.Update(
    //            existingManager.Id,
    //            manager.EmployeeNumber == 0 ? existingManager.EmployeeNumber : manager.EmployeeNumber,
    //            existingManager.Name,
    //            existingManager.Account,
    //            existingManager.Address,
    //            manager.ManagerNumber == 0 ? existingManager.ManagerNumber : manager.ManagerNumber,
    //            new List<ManagerAllContact>(), 
    //            new List<ManagerPersonalContact>(), 
    //            new List<Agent>()
    //        );


    //        _unitOfWork.ManagerRepository.Update(existingManager);
    //        _unitOfWork.Commit();


    //        var managerDto = new ManagerDto
    //        {
    //            Id = existingManager.Id,
    //            EmployeeNumber = existingManager.EmployeeNumber,
    //            ManagerNumber = existingManager.ManagerNumber,
    //            FirstName = existingManager.Name.FirstName,
    //            LastName = existingManager.Name.LastName,
    //            Email = existingManager.Account.Email,
    //            Address = new AddressDto
    //            {
    //                Street = existingManager.Address.Street,
    //                Number = existingManager.Address.Number,
    //                PostalCode = existingManager.Address.PostalCode,
    //                City = existingManager.Address.City,
    //                Country = existingManager.Address.Country
    //            }
    //        };

    //        return managerDto;
    //    }
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
