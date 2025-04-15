using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class ManagerPersonalContactsServices : IManagerPersonalContactsServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerPersonalContactsServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public ManagerPersonalContactDto Add(CreateManagerPersonalContacts managerPersonalContacts)
    {
        _unitOfWork.BeginTransaction();

        var manager = _unitOfWork.ManagerRepository.GetById(managerPersonalContacts.Manager.Id);

        if (manager == null)
        {
            throw new Exception("Manager not found.");
        }
        if (!Enum.TryParse<ContactType>(managerPersonalContacts.ContactType, true, out var contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }
      

        ManagerPersonalContact managerPersonalContactToAdd = ManagerPersonalContact.Create(
        Contact.Create(contactType, managerPersonalContacts.Value),
        manager
        );

        ManagerPersonalContact addedManagerPersonalContact;
        using (_unitOfWork)
        {
            addedManagerPersonalContact = _unitOfWork.ManagerPersonalContactRepository.Add(managerPersonalContactToAdd);
            _unitOfWork.Commit();

        }

        var managerPersonalContactsDto = new ManagerPersonalContactDto
        {
            ContactType = addedManagerPersonalContact.Contact.ContactType.ToString(),
            Value = addedManagerPersonalContact.Contact.Value,
            Manager = new ManagerDto 
            {
                EmployeeNumber = addedManagerPersonalContact.Manager.EmployeeNumber,
                ManagerNumber = addedManagerPersonalContact.Manager.ManagerNumber,
                FirstName = addedManagerPersonalContact.Manager.Name.FirstName,
                LastName = addedManagerPersonalContact.Manager.Name.LastName,
            }
        };

        return managerPersonalContactsDto;
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

    public ManagerPersonalContactDto Update(UpdateManagerPersonalContactsDto managerPersonalContacts)
    {
        var existingContact = _unitOfWork.ManagerPersonalContactRepository.GetManagerContactWithManager(managerPersonalContacts.Id);

        if (existingContact is null)
            throw new KeyNotFoundException("Agent contact not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
                string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;


            var newContactType = existingContact.Contact.ContactType;
            var newContactValue = existingContact.Contact.Value;

            if (!string.IsNullOrWhiteSpace(managerPersonalContacts.ContactType) &&
                managerPersonalContacts.ContactType != "string")
            {
                if (Enum.TryParse<ContactType>(managerPersonalContacts.ContactType, true, out var parsedType))
                {
                    newContactType = parsedType;
                }
                else
                {
                    var validValues = string.Join(", ", Enum.GetNames(typeof(ContactType)));
                    throw new ArgumentException($"Invalid contact type. Valid values are: {validValues}");
                }
            }

            newContactValue = IsValidString(managerPersonalContacts.Value, newContactValue);

            existingContact.Contact.Update(newContactType, newContactValue);


            existingContact.Update(
                existingContact.Id,
                existingContact.Contact
            );

            _unitOfWork.ManagerPersonalContactRepository.Update(existingContact);
            _unitOfWork.Commit();


            return new ManagerPersonalContactDto
            {

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
