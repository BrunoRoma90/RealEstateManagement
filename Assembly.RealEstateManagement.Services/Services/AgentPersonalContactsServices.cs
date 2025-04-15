using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
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

    public AgentPersonalContactsDto Update(UpdateAgentPersonalContactsDto agentPersonalContacts)
    {
        var existingContact = _unitOfWork.AgentPersonalContactRepository.GetAgentContactWithAgent(agentPersonalContacts.Id);

        if (existingContact is null)
            throw new KeyNotFoundException("Agent contact not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
                string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;


            var newContactType = existingContact.Contact.ContactType;
            var newContactValue = existingContact.Contact.Value;

            if (!string.IsNullOrWhiteSpace(agentPersonalContacts.ContactType) &&
                agentPersonalContacts.ContactType != "string")
            {
                if (Enum.TryParse<ContactType>(agentPersonalContacts.ContactType, true, out var parsedType))
                {
                    newContactType = parsedType;
                }
                else
                {
                    var validValues = string.Join(", ", Enum.GetNames(typeof(ContactType)));
                    throw new ArgumentException($"Invalid contact type. Valid values are: {validValues}");
                }
            }

            newContactValue = IsValidString(agentPersonalContacts.Value, newContactValue);

            existingContact.Contact.Update(newContactType, newContactValue);


            existingContact.Update(
                existingContact.Id,
                existingContact.Contact
            );

            _unitOfWork.AgentPersonalContactRepository.Update(existingContact);
            _unitOfWork.Commit();


            return new AgentPersonalContactsDto
            {

                ContactType = existingContact.Contact.ContactType.ToString(),
                Value = existingContact.Contact.Value,
                Agent = new AgentDto
                {
                    EmployeeNumber = existingContact.Agent.EmployeeNumber,
                    AgentNumber = existingContact.Agent.AgentNumber,
                    FirstName = existingContact.Agent.Name.FirstName,
                    LastName = existingContact.Agent.Name.LastName,
                }
            };
        }
    }
}
