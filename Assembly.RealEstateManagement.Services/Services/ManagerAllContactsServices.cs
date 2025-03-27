using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
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
