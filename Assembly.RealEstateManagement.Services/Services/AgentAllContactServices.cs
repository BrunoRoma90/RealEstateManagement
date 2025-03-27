using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentAllContactServices : IAgentAllContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public AgentAllContactServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AgentAllContactsDto Add(CreateAgentAllContactsDto agentAllContacts)
    {
        _unitOfWork.BeginTransaction();

        var agent = _unitOfWork.AgentRepository.GetById(agentAllContacts.Agent.Id);

        if (agent == null)
        {
            throw new Exception("Manager not found.");
        }
        if (!Enum.TryParse<ContactType>(agentAllContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        AgentAllContact agentAllContactToAdd = AgentAllContact.Create(
        Name.Create(agentAllContacts.FirstName, agentAllContacts.MiddleNames, agentAllContacts.LastName),
        Contact.Create(contactType, agentAllContacts.Value),
        agent
        );

        AgentAllContact addedAgentAllContact;
        using (_unitOfWork)
        {
            addedAgentAllContact = _unitOfWork.AgentAllContactRepository.Add(agentAllContactToAdd);
            _unitOfWork.Commit();

        }

        var agentAllContactsDto = new AgentAllContactsDto
        {
            FirstName = agentAllContacts.FirstName,
            MiddleNames = agentAllContacts.MiddleNames,
            LastName = agentAllContacts.LastName,
            ContactType = addedAgentAllContact.Contact.ContactType.ToString(),
            Value = addedAgentAllContact.Contact.Value,
            Agent = new AgentDto
            {
                EmployeeNumber = addedAgentAllContact.Agent.EmployeeNumber,
                AgentNumber = addedAgentAllContact.Agent.AgentNumber,
                FirstName = addedAgentAllContact.Agent.Name.FirstName,
                LastName = addedAgentAllContact.Agent.Name.LastName,
            }
        };

        return agentAllContactsDto;
    }

    public IEnumerable<AgentAllContactsDto> GetAgentAllContacts()
    {
        var agentAllContacts = new List<AgentAllContact>();

        agentAllContacts = _unitOfWork.AgentAllContactRepository.GetAllAgentAllContactWithAgent();

        return agentAllContacts.Select(x => new AgentAllContactsDto
        {
            FirstName = x.Name.FirstName,
            MiddleNames = x.Name.MiddleNames,
            LastName = x.Name.LastName,
            ContactType = x.Contact.ContactType.ToString(),
            Value = x.Contact.Value,
            Agent = new AgentDto
            {
                EmployeeNumber = x.Agent.EmployeeNumber,
                AgentNumber = x.Agent.AgentNumber,
                FirstName = x.Agent.Name.FirstName,
                LastName = x.Agent.Name.LastName,
            }


        }).ToList();
    }

    public List<AgentAllContactsDto> GetContactsByAgentId(int agentId)
    {
        var contacts = _unitOfWork.AgentAllContactRepository.GetAgentContacts(agentId);

        return contacts.Select(contact => new AgentAllContactsDto
        {
            FirstName = contact.Name.FirstName,
            MiddleNames = contact.Name.MiddleNames,
            LastName = contact.Name.LastName,
            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }
}
