using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentPersonalContactsServices : IAgentPersonalContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public AgentPersonalContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AgentPersonalContactsDto Add(CreateAgentPersonalContactsDto agentPersonalContacts)
    {
        _unitOfWork.BeginTransaction();

        var agent = _unitOfWork.AgentRepository.GetById(agentPersonalContacts.Agent.Id);

        if (agent == null)
        {
            throw new Exception("Agent not found.");
        }
        if (!Enum.TryParse<ContactType>(agentPersonalContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        AgentPersonalContact agentPersonalContactToAdd = AgentPersonalContact.Create(
        Contact.Create(contactType, agentPersonalContacts.Value),
        agent
        );

        AgentPersonalContact addedAgentPersonalContact;
        using (_unitOfWork)
        {
            addedAgentPersonalContact = _unitOfWork.AgentPersonalContactRepository.Add(agentPersonalContactToAdd);
            _unitOfWork.Commit();

        }

        var agentPersonalContactsDto = new AgentPersonalContactsDto
        {
            ContactType = addedAgentPersonalContact.Contact.ContactType.ToString(),
            Value = addedAgentPersonalContact.Contact.Value,
            Agent = new AgentDto
            {
                EmployeeNumber = addedAgentPersonalContact.Agent.EmployeeNumber,
                AgentNumber = addedAgentPersonalContact.Agent.AgentNumber,
                FirstName = addedAgentPersonalContact.Agent.Name.FirstName,
                LastName = addedAgentPersonalContact.Agent.Name.LastName,
            }
        };

        return agentPersonalContactsDto;
    }

    public IEnumerable<AgentPersonalContactsDto> GetAgentPersonalsContacts()
    {
        var agentPersonalContacts = new List<AgentPersonalContact>();

        agentPersonalContacts = _unitOfWork.AgentPersonalContactRepository.GetAllAgentPersonalContactWithAgent();

        return agentPersonalContacts.Select(x => new AgentPersonalContactsDto
        {
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

    public List<AgentPersonalContactsDto> GetPersonalContactsByAgentId(int agentId)
    {
        var contacts = _unitOfWork.AgentPersonalContactRepository.GetMyPersonalContacts(agentId);

        return contacts.Select(contact => new AgentPersonalContactsDto
        {

            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }
}
