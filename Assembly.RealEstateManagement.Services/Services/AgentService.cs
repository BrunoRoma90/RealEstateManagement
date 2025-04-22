
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentService : IAgentService
{
    private readonly IUnitOfWork _unitOfWork;

    public AgentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public AgentDto GetAgentById(int id)
    {
        var agent = _unitOfWork.AgentRepository.GetById(id);
        var account= _unitOfWork.AgentRepository.GetAgentAccount(id);
        var address= _unitOfWork.AgentRepository.GetAgentAddress(id);
        var manager = _unitOfWork.AgentRepository.GetManagerByAgentId(id);

        if (agent is null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }
        if (account is null)
        {
            throw new KeyNotFoundException($"Agent account with ID {id} not found.");
        }
        if (address is null)
        {
            throw new KeyNotFoundException($"Agent address ID {id} not found.");
        }
        if (manager is null)
        {
            throw new KeyNotFoundException($"Manager with ID {id} not found.");
        }
        return new AgentDto
        {
            EmployeeNumber = agent.EmployeeNumber,
            AgentNumber = agent.AgentNumber,
            FirstName = agent.Name.FirstName,
            LastName = agent.Name.LastName,
            Email = account.Email,
            Address = new AddressDto
            {
                Street = address.Street,
                Number = address.Number,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country,

            },
            Manager = new ManagerDto
            {
                EmployeeNumber = manager.EmployeeNumber,
                ManagerNumber = manager.ManagerNumber,
                FirstName = manager.Name.FirstName,
                LastName = manager.Name.LastName,

            }
        };
    }

    public IEnumerable<AgentDto> GetAgents()
    {
        var agents = new List<Agent>();

        agents = _unitOfWork.AgentRepository.GetAllAgentsWithAccount();
        agents = _unitOfWork.AgentRepository.GetAllAgentsWithAddress();
        agents = _unitOfWork.AgentRepository.GetAllAgentsWithManager();


        return agents.Select(x => new AgentDto
        {

            EmployeeNumber = x.EmployeeNumber,
            AgentNumber = x.AgentNumber,
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
            },
            Manager = new ManagerDto
            {
                EmployeeNumber = x.Manager.EmployeeNumber,
                ManagerNumber = x.Manager.ManagerNumber,
                FirstName = x.Manager.Name.FirstName,
                LastName = x.Manager.Name.LastName,
                Email = x.Manager.Account.Email,
                Address = new AddressDto
                {
                    Street = x.Manager.Address.Street,
                    Number = x.Manager.Address.Number,
                    PostalCode = x.Manager.Address.PostalCode,
                    City = x.Manager.Address.City,
                    Country = x.Manager.Address.Country
                }

            }

        }).ToList();
    }


    public AgentDto Add(CreateAgentDto agent)
    {
        _unitOfWork.BeginTransaction();

        var manager = _unitOfWork.ManagerRepository.GetById(agent.Manager.Id);
        if (manager == null)
        {
            throw new Exception("Manager not found.");
        }

        Agent agentToAdd = Agent.Create(
        Name.Create(agent.FirstName, agent.MiddleNames, agent.LastName),
        agent.Email,
        agent.Password,
        Address.Create(agent.Address.Street, agent.Address.Number, agent.Address.PostalCode, agent.Address.City, agent.Address.Country),
        agent.AgentNumber,
        agent.EmployeeNumber,
        new List<AgentPersonalContact>(),
        new List<Property>(),
        new List<AgentAllContact>(),
        manager
        );

        Agent addedAgent;
        using (_unitOfWork)
        {
            addedAgent = _unitOfWork.AgentRepository.Add(agentToAdd);
            _unitOfWork.Commit();

        }

        var agentDto = new AgentDto
        {

            EmployeeNumber = addedAgent.EmployeeNumber,
            AgentNumber = addedAgent.AgentNumber,
            FirstName = addedAgent.Name.FirstName,
            LastName = addedAgent.Name.LastName,
            Email = addedAgent.Account.Email,
            Address = new AddressDto
            {
                Street = addedAgent.Address.Street,
                Number = addedAgent.Address.Number,
                PostalCode = addedAgent.Address.PostalCode,
                City = addedAgent.Address.City,
                Country = addedAgent.Address.Country,

            },
            Manager = new ManagerDto
            {
                EmployeeNumber = addedAgent.Manager.EmployeeNumber,
                ManagerNumber = addedAgent.Manager.ManagerNumber,
                FirstName = addedAgent.Manager.Name.FirstName,
                LastName = addedAgent.Manager.Name.LastName,
             

            }



        };



        return agentDto;
    }

    public AgentDto Update(UpdateAgentDto agent)
    {
        var existingAgent = _unitOfWork.AgentRepository.GetById(agent.Id);
        var existingAddress = _unitOfWork.AgentRepository.GetAgentAddress(agent.Id);
        var existingAccount = _unitOfWork.AgentRepository.GetAgentAccount(agent.Id);
        var existingManager = _unitOfWork.AgentRepository.GetManagerByAgentId(agent.Id);

        if (existingAgent is null)
            throw new KeyNotFoundException("Agent not found.");

        if (existingAccount is null)
            throw new KeyNotFoundException("Agent account not found.");

        if (existingAddress is null)
            throw new KeyNotFoundException("Agent address not found.");

        if (existingManager is null)
            throw new KeyNotFoundException("Agent manager not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;

            existingAgent.Name.Update(
                IsValidString(agent.FirstName, existingAgent.Name.FirstName),
                IsValidArray(agent.MiddleNames, existingAgent.Name.MiddleNames),
                IsValidString(agent.LastName, existingAgent.Name.LastName));

            existingAgent.Account.Update(
                IsValidString(agent.Email, existingAgent.Account.Email),
                agent.Password ?? string.Empty);

            existingAgent.Address.UpdateAddress(
                IsValidString(agent.Address?.Street, existingAgent.Address.Street),
                agent.Address?.Number == 0 ? existingAgent.Address.Number : agent.Address.Number,
                IsValidString(agent.Address?.PostalCode, existingAgent.Address.PostalCode),
                IsValidString(agent.Address?.City, existingAgent.Address.City),
                IsValidString(agent.Address?.Country, existingAgent.Address.Country)
            );

            var newManager = agent.ManagerId.HasValue && agent.ManagerId.Value != 0 && agent.ManagerId.Value != existingManager.Id
            ? _unitOfWork.ManagerRepository.GetById(agent.ManagerId.Value)
            : existingManager;

            if (newManager is null)
                throw new KeyNotFoundException("New manager not found.");


            existingAgent.Update(
                existingAgent.Id,
                existingAgent.Name,
                IsValidString(agent.Email, existingAgent.Account.Email),
                agent.Password ?? string.Empty,
                existingAgent.Address,
                agent.EmployeeNumber == 0 ? existingAgent.EmployeeNumber : agent.EmployeeNumber,
                agent.AgentNumber == 0 ? existingAgent.AgentNumber : agent.AgentNumber,
                new List<AgentPersonalContact>(),
                new List<Property>(),
                new List<AgentAllContact>(),
                newManager
            );


            _unitOfWork.AgentRepository.Update(existingAgent);
            _unitOfWork.Commit();


            var agentDto = new AgentDto
            {
                Id = existingAgent.Id,
                EmployeeNumber = existingAgent.EmployeeNumber,
                AgentNumber = existingAgent.AgentNumber,
                FirstName = existingAgent.Name.FirstName,
                LastName = existingAgent.Name.LastName,
                Email = existingAgent.Account.Email,
                Address = new AddressDto
                {
                    Street = existingAgent.Address.Street,
                    Number = existingAgent.Address.Number,
                    PostalCode = existingAgent.Address.PostalCode,
                    City = existingAgent.Address.City,
                    Country = existingAgent.Address.Country
                }
            };

            return agentDto;
        }
    }



    //public AgentDto Update(UpdateAgentDto agent)
    //{
    //    _unitOfWork.BeginTransaction();

    //    var existingAgent = _unitOfWork.AgentRepository.GetById(agent.Id);
    //    if (existingAgent == null)
    //    {
    //        throw new Exception("Agent not found.");
    //    }

    //    var manager = _unitOfWork.ManagerRepository.GetById(agent.Manager.Id);
    //    if (manager == null)
    //    {
    //        throw new Exception("Manager not found.");
    //    }


    //    Agent.Update(existingAgent.Id,
    //        Name.UpdateName(agent.FirstName, agent.MiddleNames, agent.LastName),
    //        Account.Update(agent.Email, agent.Password),
    //        Address.UpdateAddress( agent.Address.Street, agent.Address.Number, agent.Address.PostalCode, agent.Address.City, agent.Address.Country),
    //        agent.AgentNumber,
    //        agent.EmployeeNumber,
    //        existingAgent.AgentPersonalContact, // preserva os contactos
    //        existingAgent.ManagedProperty,      // preserva propriedades
    //        existingAgent.AgentAllContact,      // preserva contactos gerais
    //        manager
    //    );

    //    Agent updatedAgent;
    //    using (_unitOfWork)
    //    {
    //        updatedAgent = _unitOfWork.AgentRepository.Update(existingAgent);
    //        _unitOfWork.Commit();
    //    }

    //    var agentDto = new AgentDto
    //    {
    //        EmployeeNumber = updatedAgent.EmployeeNumber,
    //        AgentNumber = updatedAgent.AgentNumber,
    //        FirstName = updatedAgent.Name.FirstName,
    //        LastName = updatedAgent.Name.LastName,
    //        Email = updatedAgent.Account.Email,
    //        Address = new AddressDto
    //        {
    //            Street = updatedAgent.Address.Street,
    //            Number = updatedAgent.Address.Number,
    //            PostalCode = updatedAgent.Address.PostalCode,
    //            City = updatedAgent.Address.City,
    //            Country = updatedAgent.Address.Country,
    //        },
    //        Manager = new ManagerDto
    //        {
    //            EmployeeNumber = updatedAgent.Manager.EmployeeNumber,
    //            ManagerNumber = updatedAgent.Manager.ManagerNumber,
    //            FirstName = updatedAgent.Manager.Name.FirstName,
    //            LastName = updatedAgent.Manager.Name.LastName,
    //        }
    //    };

    //    return agentDto;
    //}



    //public void AddVisitToMyList(int agentId, Visit visit)
    //{

    //    _agentRepository.AddVisitToMyList(agentId,visit);

    //}

    //public void RemoveVisitToMyList(int agentId, Visit visit)
    //{
    //    _agentRepository.RemoveVisitToMyList(agentId, visit);   
    //}

    //public List<Visit> GetAllVisits(int agentId)
    //{
    //    if (agentId <= 0)
    //    {
    //        throw new ArgumentException("Agent ID must be greater than zero.", nameof(agentId));
    //    }


    //    return _agentRepository.GetVisitsByAgentId(agentId);
    //}

    //public void MarkAvailabilityProperty(Property property, Availability availability, Agent agent)
    //{
    //    if (property == null)
    //    {
    //        throw new ArgumentNullException(nameof(property), "Property cannot be null.");
    //    }
    //    bool existingProperty = false;
    //    foreach (var managedProperty in agent.ManagedProperties)
    //    {
    //        if (managedProperty.Id == property.Id)
    //        {
    //            managedProperty.UpdateAvailability(availability);
    //            existingProperty = true;
    //            break;
    //        }
    //    }
    //    if (!existingProperty)
    //    {
    //        {
    //            throw new InvalidOperationException("Property cannot be updated because it is not managed by this agent.");
    //        }
    //    }

    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    _agentRepository.AddNotes(visitId, notes);
    //}

    //public void AddContactToMyList(int angentId, Contact contact)
    //{
    //    _agentRepository.AddContactToMyList(angentId, contact);
    //}
    //public void RemoveContactToMyList(int agentId, Contact contact)
    //{
    //    _agentRepository.RemoveContactFromMyList(agentId, contact);
    //}

    //public List<Contact> GetMyContacts(int agentId)
    //{
    //    return _agentRepository.GetMyContacts(agentId);
    //}


    //public void AddPropertyToAgent(int agentId, Property property)
    //{

    //    _agentRepository.AddPropertyToMyList(agentId, property);
    //}

    //public void RemovePropertyFromAgent(int agentId, Property property)
    //{
    //    _agentRepository.RemovePropertyFromAgent(agentId, property);
    //}


}
