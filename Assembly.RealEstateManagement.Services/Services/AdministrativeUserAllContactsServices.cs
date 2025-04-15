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

    public List<AdministrativeUsersAllContactsDto> GetContactsByAdministrativeUserId(int administrativeUserId)
    {
        var contacts = _unitOfWork.AdministrativeUserAllContactRepository.GetAdministrativeUserContacts(administrativeUserId);

        return contacts.Select(contact => new AdministrativeUsersAllContactsDto
        {
            FirstName = contact.Name.FirstName,
            MiddleNames = contact.Name.MiddleNames,
            LastName = contact.Name.LastName,
            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }


    public AdministrativeUsersAllContactsDto Add(CreateAdministrativeUserAllContactsDto administrativeUserAllContacts)
    {
        _unitOfWork.BeginTransaction();

        var administrativeUser = _unitOfWork.AdministrativeUsersRepository.GetById(administrativeUserAllContacts.AdministrativeUser.Id);

        if (administrativeUser == null)
        {
            throw new Exception("AdministrativeUser not found.");
        }
        if (!Enum.TryParse<ContactType>(administrativeUserAllContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        AdministrativeUserAllContact administrativeUserAllContactToAdd = AdministrativeUserAllContact.Create(
        Name.Create(administrativeUserAllContacts.FirstName, administrativeUserAllContacts.MiddleNames, administrativeUserAllContacts.LastName),
        Contact.Create(contactType, administrativeUserAllContacts.Value),
        administrativeUser
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

    public AdministrativeUsersAllContactsDto Update(UpdateAdministrativeUserAllContactsDto administrativeUserAllContacts)
    {

        var existingContact = _unitOfWork.AdministrativeUserAllContactRepository.GetAdministrativeUserContactWithAdministrativeUser(administrativeUserAllContacts.Id);

        if (existingContact is null)
            throw new KeyNotFoundException("Administrative user contact not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();

            
            string IsValidString(string? value, string current) =>
                string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;

            
            existingContact.Name.Update(
                IsValidString(administrativeUserAllContacts.FirstName, existingContact.Name.FirstName),
                IsValidArray(administrativeUserAllContacts.MiddleNames, existingContact.Name.MiddleNames),
                IsValidString(administrativeUserAllContacts.LastName, existingContact.Name.LastName)
            );

            
            var newContactType = existingContact.Contact.ContactType;
            var newContactValue = existingContact.Contact.Value;

            if (!string.IsNullOrWhiteSpace(administrativeUserAllContacts.ContactType) &&
                administrativeUserAllContacts.ContactType != "string")
            {
                if (Enum.TryParse<ContactType>(administrativeUserAllContacts.ContactType, true, out var parsedType))
                {
                    newContactType = parsedType;
                }
                else
                {
                    var validValues = string.Join(", ", Enum.GetNames(typeof(ContactType)));
                    throw new ArgumentException($"Invalid contact type. Valid values are: {validValues}");
                }
            }

            newContactValue = IsValidString(administrativeUserAllContacts.Value, newContactValue);

            existingContact.Contact.Update(newContactType, newContactValue);

            
            existingContact.Update(
                existingContact.Id,
                existingContact.Name,
                existingContact.Contact
            );

            _unitOfWork.AdministrativeUserAllContactRepository.Update(existingContact);
            _unitOfWork.Commit();

            
            return new AdministrativeUsersAllContactsDto
            {
                FirstName = existingContact.Name.FirstName,
                MiddleNames = existingContact.Name.MiddleNames,
                LastName = existingContact.Name.LastName,
                ContactType = existingContact.Contact.ContactType.ToString(),
                Value = existingContact.Contact.Value,
                AdministrativeUser = new AdministrativeUserDto
                {
                    EmployeeNumber = existingContact.AdministrativeUser.EmployeeNumber,
                    AdministrativeNumber = existingContact.AdministrativeUser.AdministrativeNumber,
                    FirstName = existingContact.AdministrativeUser.Name.FirstName,
                    LastName = existingContact.AdministrativeUser.Name.LastName,
                }
            };
        }
        
    }
}
