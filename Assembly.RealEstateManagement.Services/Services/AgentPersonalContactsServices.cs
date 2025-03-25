using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentPersonalContactsServices : IAgentPersonalContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public AgentPersonalContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public ManagerPersonalContactDto Add(CreateAgentPersonalContactsDto agentPersonalContacts)
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

        var agentPersonalContactsDto = new ManagerPersonalContactDto
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

    public IEnumerable<ManagerPersonalContactDto> GetManagerPersonalsContacts()
    {
        var managerPersonalContacts = new List<ManagerPersonalContact>();

        managerPersonalContacts = _unitOfWork.ManagerPersonalContactRepository.GetAllManagerPersonalContactWithManager();

        return managerPersonalContacts.Select(x => new ManagerPersonalContactDto
        {
            ContactType = x.Contact.ContactType.ToString(),
            Value = x.Contact.Value,
            Manager = new ManagerDto
            {
                EmployeeNumber = x.Manager.EmployeeNumber,
                ManagerNumber = x.Manager.ManagerNumber,
                FirstName = x.Manager.Name.FirstName,
                LastName = x.Manager.Name.LastName,
            }


        }).ToList();
    }

    public List<ManagerPersonalContactDto> GetContactsByManagerId(int managerId)
    {
        var contacts = _unitOfWork.ManagerPersonalContactRepository.GetMyPersonalContacts(managerId);

        return contacts.Select(contact => new ManagerPersonalContactDto
        {

            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }
}
