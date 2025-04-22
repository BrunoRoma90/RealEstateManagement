using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Manager;

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
        administrativeUser.Email,
        administrativeUser.Password,
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

    public AdministrativeUserDto GetAdministrativeUserById(int id)
    {
        var administrativeUser = _unitOfWork.AdministrativeUsersRepository.GetById(id);
        var account = _unitOfWork.AdministrativeUsersRepository.GetAdministrativeUserAccount(id);
        var address = _unitOfWork.AdministrativeUsersRepository.GetAdministrativeUserAddress(id);
        if (administrativeUser == null)
        {
            throw new KeyNotFoundException($"AdministrativeUser with ID {id} not found.");
        }
        if (account is null)
        {
            throw new KeyNotFoundException($"AdministrativeUser account with ID {id} not found.");
        }
        if (address is null)
        {
            throw new KeyNotFoundException($"AdministrativeUser address with ID {id} not found.");
        }
        return new AdministrativeUserDto 
        {
            EmployeeNumber = administrativeUser.EmployeeNumber,
            AdministrativeNumber = administrativeUser.AdministrativeNumber,
            FirstName = administrativeUser.Name.FirstName,
            LastName = administrativeUser.Name.LastName,
            Email = administrativeUser.Account.Email,
            Address = new AddressDto
            {
                Street = administrativeUser.Address.Street,
                Number = administrativeUser.Address.Number,
                PostalCode = administrativeUser.Address.PostalCode,
                City = administrativeUser.Address.City,
                Country = administrativeUser.Address.Country,

            }
        };
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

    public AdministrativeUserDto Update(UpdateAdministrativeUserDto administrativeUser)
    {
        var existingAdministrativeUser = _unitOfWork.AdministrativeUsersRepository.GetById(administrativeUser.Id);
        var existingAddress = _unitOfWork.AdministrativeUsersRepository.GetAdministrativeUserAddress(administrativeUser.Id);
        var existingAccount = _unitOfWork.AdministrativeUsersRepository.GetAdministrativeUserAccount(administrativeUser.Id);

        if (existingAdministrativeUser is null)
            throw new KeyNotFoundException("AdministrativeUser not found.");

        if (existingAccount is null)
            throw new KeyNotFoundException("AdministrativeUser account not found.");

        if (existingAddress is null)
            throw new KeyNotFoundException("AdministrativeUser address not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;

            existingAdministrativeUser.Name.Update(
                IsValidString(administrativeUser.FirstName, existingAdministrativeUser.Name.FirstName),
                IsValidArray(administrativeUser.MiddleNames, existingAdministrativeUser.Name.MiddleNames),
                IsValidString(administrativeUser.LastName, existingAdministrativeUser.Name.LastName));

            existingAdministrativeUser.Account.Update(
                IsValidString(administrativeUser.Email, existingAdministrativeUser.Account.Email),
                administrativeUser.Password ?? string.Empty);

            existingAdministrativeUser.Address.UpdateAddress(
                IsValidString(administrativeUser.Address?.Street, existingAdministrativeUser.Address.Street),
                administrativeUser.Address?.Number == 0 ? existingAdministrativeUser.Address.Number : administrativeUser.Address.Number,
                IsValidString(administrativeUser.Address?.PostalCode, existingAdministrativeUser.Address.PostalCode),
                IsValidString(administrativeUser.Address?.City, existingAdministrativeUser.Address.City),
                IsValidString(administrativeUser.Address?.Country, existingAdministrativeUser.Address.Country)
            );


            existingAdministrativeUser.Update(
                existingAdministrativeUser.Id,
                existingAdministrativeUser.Name,
                IsValidString(administrativeUser.Email, existingAdministrativeUser.Account.Email),
                administrativeUser.Password ?? string.Empty,
                existingAdministrativeUser.Address,
                administrativeUser.EmployeeNumber == 0 ? existingAdministrativeUser.EmployeeNumber : administrativeUser.EmployeeNumber,
                administrativeUser.AdministrativeNumber == 0 ? existingAdministrativeUser.AdministrativeNumber : administrativeUser.AdministrativeNumber,
                new List<AdministrativeUserAllContact>(),
                new List<AdministrativeUserPersonalContact>()

            );


            _unitOfWork.AdministrativeUsersRepository.Update(existingAdministrativeUser);
            _unitOfWork.Commit();


            var administrativeUserDto = new AdministrativeUserDto
            {
                Id = existingAdministrativeUser.Id,
                EmployeeNumber = existingAdministrativeUser.EmployeeNumber,
                AdministrativeNumber = existingAdministrativeUser.AdministrativeNumber,
                FirstName = existingAdministrativeUser.Name.FirstName,
                LastName = existingAdministrativeUser.Name.LastName,
                Email = existingAdministrativeUser.Account.Email,
                Address = new AddressDto
                {
                    Street = existingAdministrativeUser.Address.Street,
                    Number = existingAdministrativeUser.Address.Number,
                    PostalCode = existingAdministrativeUser.Address.PostalCode,
                    City = existingAdministrativeUser.Address.City,
                    Country = existingAdministrativeUser.Address.Country
                }
            };

            return administrativeUserDto;
        }
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

