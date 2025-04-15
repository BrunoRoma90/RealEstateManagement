using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class ManagerAllContactsServices : IManagerAllContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerAllContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public ManagerAllContactsDto Add(CreateManagerAllContactsDto managerAllContacts)
    {
        _unitOfWork.BeginTransaction();

        var manager = _unitOfWork.ManagerRepository.GetById(managerAllContacts.Manager.Id);

        if (manager == null)
        {
            throw new Exception("Manager not found.");
        }
        if (!Enum.TryParse<ContactType>(managerAllContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }


        ManagerAllContact managerAllContactToAdd = ManagerAllContact.Create(
        Name.Create(managerAllContacts.FirstName, managerAllContacts.MiddleNames, managerAllContacts.LastName),
        Contact.Create(contactType, managerAllContacts.Value),
        manager
        );

        ManagerAllContact addedManagerAllContact;
        using (_unitOfWork)
        {
            addedManagerAllContact = _unitOfWork.ManagerAllContactRepository.Add(managerAllContactToAdd);
            _unitOfWork.Commit();

        }

        var managerAllContactsDto = new ManagerAllContactsDto
        {
            FirstName = managerAllContacts.FirstName,
            MiddleNames = managerAllContacts.MiddleNames,
            LastName = managerAllContacts.LastName,
            ContactType = addedManagerAllContact.Contact.ContactType.ToString(),
            Value = addedManagerAllContact.Contact.Value,
            Manager = new ManagerDto
            {
                EmployeeNumber = addedManagerAllContact.Manager.EmployeeNumber,
                ManagerNumber = addedManagerAllContact.Manager.ManagerNumber,
                FirstName = addedManagerAllContact.Manager.Name.FirstName,
                LastName = addedManagerAllContact.Manager.Name.LastName,
            }
        };

        return managerAllContactsDto;
    }

    public IEnumerable<ManagerAllContactsDto> GetManagerAllContacts()
    {
        var managerAllContacts = new List<ManagerAllContact>();

        managerAllContacts = _unitOfWork.ManagerAllContactRepository.GetAllManagerAllContactWithManager();

        return managerAllContacts.Select(x => new ManagerAllContactsDto
        {
            FirstName = x.Name.FirstName,
            MiddleNames = x.Name.MiddleNames,
            LastName = x.Name.LastName,
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

    public List<ManagerAllContactsDto> GetAllContactsByManagerId(int managerId)
    {
        var contacts = _unitOfWork.ManagerAllContactRepository.GetManagerContacts(managerId);

        return contacts.Select(contact => new ManagerAllContactsDto
        {
            FirstName = contact.Name.FirstName,
            MiddleNames = contact.Name.MiddleNames,
            LastName = contact.Name.LastName,
            ContactType = contact.Contact.ContactType.ToString(),
            Value = contact.Contact.Value
        }).ToList();
    }



    public ManagerAllContactsDto Update(UpdateManagerAllContactsDto managerAllContacts)
    {

        var existingContact = _unitOfWork.ManagerAllContactRepository.GetManagerContactWithManager(managerAllContacts.Id);

        if (existingContact is null)
            throw new KeyNotFoundException("Agent contact not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
                string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;


            existingContact.Name.Update(
                IsValidString(managerAllContacts.FirstName, existingContact.Name.FirstName),
                IsValidArray(managerAllContacts.MiddleNames, existingContact.Name.MiddleNames),
                IsValidString(managerAllContacts.LastName, existingContact.Name.LastName)
            );


            var newContactType = existingContact.Contact.ContactType;
            var newContactValue = existingContact.Contact.Value;

            if (!string.IsNullOrWhiteSpace(managerAllContacts.ContactType) &&
                managerAllContacts.ContactType != "string")
            {
                if (Enum.TryParse<ContactType>(managerAllContacts.ContactType, true, out var parsedType))
                {
                    newContactType = parsedType;
                }
                else
                {
                    var validValues = string.Join(", ", Enum.GetNames(typeof(ContactType)));
                    throw new ArgumentException($"Invalid contact type. Valid values are: {validValues}");
                }
            }

            newContactValue = IsValidString(managerAllContacts.Value, newContactValue);

            existingContact.Contact.Update(newContactType, newContactValue);


            existingContact.Update(
                existingContact.Id,
                existingContact.Name,
                existingContact.Contact
            );

            _unitOfWork.ManagerAllContactRepository.Update(existingContact);
            _unitOfWork.Commit();


            return new ManagerAllContactsDto
            {
                FirstName = existingContact.Name.FirstName,
                MiddleNames = existingContact.Name.MiddleNames,
                LastName = existingContact.Name.LastName,
                ContactType = existingContact.Contact.ContactType.ToString(),
                Value = existingContact.Contact.Value,
                Manager = new ManagerDto
                {
                    EmployeeNumber = existingContact.Manager.EmployeeNumber,
                    ManagerNumber = existingContact.Manager.ManagerNumber,
                    FirstName = existingContact.Manager.Name.FirstName,
                    LastName = existingContact.Manager.Name.LastName,
                }
            };
        }

    }
}
