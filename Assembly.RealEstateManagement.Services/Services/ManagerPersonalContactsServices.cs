using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
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
}
