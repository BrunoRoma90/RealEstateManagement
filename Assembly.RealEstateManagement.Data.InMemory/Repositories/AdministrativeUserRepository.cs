﻿
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdministrativeUserRepository : IAdministrativeUsersRepository
{
    private readonly  Database _db;
    private readonly AgentRepository _agentRepository;
    public AdministrativeUserRepository(Database database, AgentRepository agentRepository)
    {
        _db = database;
        _agentRepository = agentRepository;
    }

    public AdministrativeUsers Add(AdministrativeUsers administrativeUser)
    {
        _db.AdministrativeUsers.Add(administrativeUser);
        return administrativeUser;
    }

    public AdministrativeUsers Delete(AdministrativeUsers administrativeUser)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var existingAdministrativeUser in administrativeUsers)
        { 
            if (existingAdministrativeUser.Id == administrativeUser.Id) 
            { 
                _db.AdministrativeUsers.Remove(existingAdministrativeUser);
            }
        }
        throw new KeyNotFoundException($"Administrative was not found.");
    }

    public AdministrativeUsers Delete(int id)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var administrativeUser in administrativeUsers)
        {
            if (administrativeUser.Id == id)
            {
                _db.AdministrativeUsers.Remove(administrativeUser);

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }

    public Agent GetAgent(int id)
    {
        return _agentRepository.GetById(id);
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public List<AdministrativeUsers> GetAll()
    {
        var allAdministrativeUsers = new List<AdministrativeUsers>();
        foreach (var administrativeUser in _db.AdministrativeUsers)
        {
            allAdministrativeUsers.Add(administrativeUser);
        }
        return allAdministrativeUsers;
    }

    public AdministrativeUsers GetById(int id)
    {
        foreach (var administrativeUser in _db.AdministrativeUsers)
        {
            if (administrativeUser.Id == id)
            {
                return administrativeUser;

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }

    public Client GetClient(int id)
    {
        throw new NotImplementedException();
    }

    public List<Client> GetClients()
    {
        throw new NotImplementedException();
    }

    public Manager GetManager(int id)
    {
        throw new NotImplementedException();
    }

    public List<Manager> GetManagers()
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetVisits()
    {
        throw new NotImplementedException();
    }

    public AdministrativeUsers Update(AdministrativeUsers administrativeUser)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var existingAdmin in administrativeUsers)
        {
            if (existingAdmin.Id == administrativeUser.Id)
            {
                existingAdmin.UpdateAdministrativeUser(administrativeUser.Name, administrativeUser.Account, administrativeUser.Contact, administrativeUser.Address,
                    administrativeUser.EmployeeNumber, administrativeUser.AdministrativeNumber, administrativeUser.Clients, administrativeUser.Employees);

                return existingAdmin;
            }
        }
        throw new KeyNotFoundException($"(AdministrativeUser was not found.");
    }

}
