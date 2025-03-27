using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AdministrativeUserAllContactsServices : IAdministrativeUsersAllContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministrativeUserAllContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AdministrativeUsersAllContactsDto Add(CreateAdministrativeUserAllContactsDto administrativeUserAllContacts)
    {
        _unitOfWork.BeginTransaction();

        var agent = _unitOfWork.AdministrativeUsersRepository.GetById(administrativeUserAllContacts.AdministrativeUser.Id);

        if (agent == null)
        {
            throw new Exception("Manager not found.");
        }
        if (!Enum.TryParse<ContactType>(administrativeUserAllContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        AdministrativeUserAllContact administrativeUserAllContactToAdd = AdministrativeUserAllContact.Create(
        Name.Create(administrativeUserAllContacts.FirstName, administrativeUserAllContacts.MiddleNames, administrativeUserAllContacts.LastName),
        Contact.Create(contactType, administrativeUserAllContacts.Value),
        agent
        );

        AdministrativeUserAllContact addedAdministrativeUserAllContact;
        using (_unitOfWork)
        {
            addedAdministrativeUserAllContact = _unitOfWork.AdministrativeUserAllContactRepository.Add(administrativeUserAllContactToAdd);
            _unitOfWork.Commit();

        }

        var administrativeUserAllContactsDto = new AdministrativeUsersAllContactsDto
        {
            FirstName = administrativeUserAllContacts.FirstName,
            MiddleNames = administrativeUserAllContacts.MiddleNames,
            LastName = administrativeUserAllContacts.LastName,
            ContactType = addedAdministrativeUserAllContact.Contact.ContactType.ToString(),
            Value = addedAdministrativeUserAllContact.Contact.Value,
            AdministrativeUser = new AdministrativeUserDto
            {
                EmployeeNumber = addedAdministrativeUserAllContact.AdministrativeUser.EmployeeNumber,
                AdministrativeNumber = addedAdministrativeUserAllContact.AdministrativeUser.AdministrativeNumber,
                FirstName = addedAdministrativeUserAllContact.AdministrativeUser.Name.FirstName,
                LastName = addedAdministrativeUserAllContact.AdministrativeUser.Name.LastName,
            }
        };

        return administrativeUserAllContactsDto;
    }

    public IEnumerable<AdministrativeUsersAllContactsDto> GetAdministrativeUserAllContacts()
    {
        var administrativeUserAllContacts = new List<AdministrativeUserAllContact>();

        administrativeUserAllContacts = _unitOfWork.AdministrativeUserAllContactRepository.GetAllAdministrativeUserAllContactWithAdministrativeUser();

        return administrativeUserAllContacts.Select(x => new AdministrativeUsersAllContactsDto
        {
            FirstName = x.Name.FirstName,
            MiddleNames = x.Name.MiddleNames,
            LastName = x.Name.LastName,
            ContactType = x.Contact.ContactType.ToString(),
            Value = x.Contact.Value,
            AdministrativeUser = new AdministrativeUserDto
            {
                EmployeeNumber = x.AdministrativeUser.EmployeeNumber,
                AdministrativeNumber = x.AdministrativeUser.AdministrativeNumber,
                FirstName = x.AdministrativeUser.Name.FirstName,
                LastName = x.AdministrativeUser.Name.LastName,
            }


        }).ToList();
    }

    public List<AdministrativeUsersAllContactsDto> GetContactsByAdministrativeUserId(int agentId)
    {
        var contacts = _unitOfWork.AgentAllContactRepository.GetAgentContacts(agentId);

        return contacts.Select(contact => new AdministrativeUsersAllContactsDto
        {
            FirstName = contact.Name.FirstName,
            MiddleNames = contact.Name.MiddleNames,
            LastName = contact.Name.LastName,
            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }

}
