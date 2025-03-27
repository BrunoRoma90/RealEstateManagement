using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Services;

public class AdministrativeUserService : IAdministrativeUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministrativeUserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AdministrativeUserDto Add(CreateAdministrativeUserDto administrativeUser)
    {
        _unitOfWork.BeginTransaction();

        AdministrativeUser administrativeUserToAdd = AdministrativeUser.Create(
        Name.Create(administrativeUser.FirstName, administrativeUser.MiddleNames, administrativeUser.LastName),
        Account.Create(administrativeUser.Email, administrativeUser.Password),
        Address.Create(administrativeUser.Address.Street, administrativeUser.Address.Number, administrativeUser.Address.PostalCode, administrativeUser.Address.City, administrativeUser.Address.Country),
        administrativeUser.EmployeeNumber,
        administrativeUser.AdministrativeNumber,
        new List<AdministrativeUserAllContact>(),
        new List<AdministrativeUserPersonalContact>()
         );

        AdministrativeUser addedAdministrativeUser;
        using (_unitOfWork)
        {
            addedAdministrativeUser = _unitOfWork.AdministrativeUsersRepository.Add(administrativeUserToAdd);
            _unitOfWork.Commit();

        }

        var administrativeUserDto = new AdministrativeUserDto
        {

            EmployeeNumber = addedAdministrativeUser.EmployeeNumber,
            AdministrativeNumber = addedAdministrativeUser.AdministrativeNumber,
            FirstName = addedAdministrativeUser.Name.FirstName,
            LastName = addedAdministrativeUser.Name.LastName,
            Email = addedAdministrativeUser.Account.Email,
            Address = new AddressDto
            {
                Street = addedAdministrativeUser.Address.Street,
                Number = addedAdministrativeUser.Address.Number,
                PostalCode = addedAdministrativeUser.Address.PostalCode,
                City = addedAdministrativeUser.Address.City,
                Country = addedAdministrativeUser.Address.Country,

            }


        };



        return administrativeUserDto;
    }

    public AdministrativeUser GetAdministrativeUserById(int id)
    {
        var administrativeUser = _unitOfWork.AdministrativeUsersRepository.GetById(id);
        if (administrativeUser == null)
        {
            throw new KeyNotFoundException($"Manager with ID {id} not found.");
        }
        return administrativeUser;
    }

    public IEnumerable<AdministrativeUserDto> GetAdministrativeUsers()
    {
        var administrativeUsers = new List<AdministrativeUser>();

        administrativeUsers = _unitOfWork.AdministrativeUsersRepository.GetAllAdministrativeUserWithAccount();
        administrativeUsers = _unitOfWork.AdministrativeUsersRepository.GetAllAdministrativeUserWithAddress();

        return administrativeUsers.Select(x => new AdministrativeUserDto
        {

            EmployeeNumber = x.EmployeeNumber,
            AdministrativeNumber = x.AdministrativeNumber,
            FirstName = x.Name.FirstName,
            LastName = x.Name.LastName,
            Email = x.Account.Email,
            Address = new AddressDto
            {
                Street = x.Address.Street,
                Number = x.Address.Number,
                PostalCode = x.Address.PostalCode,
                City = x.Address.City,
                Country = x.Address.Country,
            }

        }).ToList();
    }

    //public void AddNotes(int visitId, string notes)
    //{
    //    _administrativesUserRepository.AddNotes(visitId, notes);
    //}

    //public void AddVisit(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisit(visit);
    //}

    //public void AddVisitToAgent(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisitToAgent(visit);
    //}

    //public void AddVisitToClient(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisitToClient(visit);
    //}

    //public Client CreateClient(Client client)
    //{
    //    return _administrativesUserRepository.CreateClient(client);
    //}

    //public List<Client> GetAllClients()
    //{
    //    return _administrativesUserRepository.GetClients();
    //}

    //public List<Visit> GetAllVisitsByAgentId(int agentId)
    //{
    //    return _administrativesUserRepository.GetVisitsByAgentId(agentId);
    //}

    //public List<Visit> GetAllVisitsByClientId(int clientId)
    //{
    //    return _administrativesUserRepository.GetVisitsByClientId(clientId);
    //}

    //public Visit GetVisitByAgentId(int agentId)
    //{
    //    return _administrativesUserRepository.GetVisitByAgentId(agentId);
    //}

    //public Visit GetVisitByClientId(int clientId)
    //{
    //    return _administrativesUserRepository.GetVisitByClientId(clientId);
    //}

    //public Visit UpdateVisit(Visit visit)
    //{
    //    return _administrativesUserRepository.UpdateVisit(visit);
    //}

}
