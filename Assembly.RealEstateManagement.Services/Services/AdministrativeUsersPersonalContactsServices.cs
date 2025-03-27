using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AdministrativeUsersPersonalContactsServices : IAdministrativeUsersPersonalContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministrativeUsersPersonalContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AdministrativeUserPersonalContactDto Add(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContacts)
    {
        _unitOfWork.BeginTransaction();

        var administrativeUser = _unitOfWork.AdministrativeUsersRepository.GetById(administrativeUserPersonalContacts.AdministrativeUser.Id);

        if (administrativeUser == null)
        {
            throw new Exception("Manager not found.");
        }
        if (!Enum.TryParse<ContactType>(administrativeUserPersonalContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        AdministrativeUserPersonalContact administrativeUserPersonalContactToAdd = AdministrativeUserPersonalContact.Create(
        Contact.Create(contactType, administrativeUserPersonalContacts.Value),
        administrativeUser
        );

        AdministrativeUserPersonalContact administrativeUserPersonalContact;
        using (_unitOfWork)
        {
            administrativeUserPersonalContact = _unitOfWork.AdministrativeUserPersonalContactRepository.Add(administrativeUserPersonalContactToAdd);
            _unitOfWork.Commit();

        }

        var administrativeUserPersonalContactsDto = new AdministrativeUserPersonalContactDto
        {
            ContactType = administrativeUserPersonalContact.Contact.ContactType.ToString(),
            Value = administrativeUserPersonalContact.Contact.Value,
            AdministrativeUser = new AdministrativeUserDto
            {
                EmployeeNumber = administrativeUserPersonalContact.AdministrativeUser.EmployeeNumber,
                AdministrativeNumber = administrativeUserPersonalContact.AdministrativeUser.AdministrativeNumber,
                FirstName = administrativeUserPersonalContact.AdministrativeUser.Name.FirstName,
                LastName = administrativeUserPersonalContact.AdministrativeUser.Name.LastName,
            }
        };

        return administrativeUserPersonalContactsDto;
    }

    public IEnumerable<AdministrativeUserPersonalContactDto> GetAdministrativeUsersPersonalsContacts()
    {
        var administrativeUserPersonalContacts = new List<AdministrativeUserPersonalContact>();

        administrativeUserPersonalContacts = _unitOfWork.AdministrativeUserPersonalContactRepository.GetAllAdministrativeUserPersonalContactWithAdministrativeUser();

        return administrativeUserPersonalContacts.Select(x => new AdministrativeUserPersonalContactDto
        {
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

    public List<AdministrativeUserPersonalContactDto> GetPersonalContactsByAdministrativeUserId(int administrativeUserId)
    {
        var contacts = _unitOfWork.AdministrativeUserPersonalContactRepository.GetMyPersonalContacts(administrativeUserId);

        return contacts.Select(contact => new AdministrativeUserPersonalContactDto
        {

            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }
}
