
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
        Account.Create(agent.Email, agent.Password),
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
                //Email = addedAgent.Manager.Account.Email,
                //Address = new AddressDto
                //{
                //    Street = addedAgent.Manager.Address.Street,
                //    Number = addedAgent.Manager.Address.Number,
                //    PostalCode = addedAgent.Manager.Address.PostalCode,
                //    City = addedAgent.Manager.Address.City,
                //    Country = addedAgent.Manager.Address.Country
                //}

            }



        };



        return agentDto;
    }

    public AgentDto GetAgentById(int id)
    {
        var agent = _unitOfWork.AgentRepository.GetById(id);
        if (agent is null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }
        return new AgentDto
        {
            EmployeeNumber = agent.EmployeeNumber,
            AgentNumber = agent.AgentNumber,
            FirstName = agent.Name.FirstName,
            LastName = agent.Name.LastName,
            Email = agent.Account.Email,
            Address = new AddressDto
            {
                Street = agent.Address.Street,
                Number = agent.Address.Number,
                PostalCode = agent.Address.PostalCode,
                City = agent.Address.City,
                Country = agent.Address.Country,

            },
            Manager = new ManagerDto
            {
                EmployeeNumber = agent.Manager.EmployeeNumber,
                ManagerNumber = agent.Manager.ManagerNumber,
                FirstName = agent.Manager.Name.FirstName,
                LastName = agent.Manager.Name.LastName,
                //Email = addedAgent.Manager.Account.Email,
                //Address = new AddressDto
                //{
                //    Street = addedAgent.Manager.Address.Street,
                //    Number = addedAgent.Manager.Address.Number,
                //    PostalCode = addedAgent.Manager.Address.PostalCode,
                //    City = addedAgent.Manager.Address.City,
                //    Country = addedAgent.Manager.Address.Country
                //}

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
