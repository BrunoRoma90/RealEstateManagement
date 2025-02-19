using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }
    public Manager Manager { get; private set; }



    public ManagerPersonalContact() { }

    public ManagerPersonalContact(int id,Contact contact, Manager manager) : this()
    {
        ValidateManagerPersonalContact(contact,manager);
        Contact = contact;
        Manager = manager;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }


    private ManagerPersonalContact(Contact contact, Manager manager) : this()
    {
        ValidateManagerPersonalContact(contact, manager);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        Manager = Manager.Create(manager.EmployeeNumber, manager.Name, manager.Account,
         manager.Address, manager.ManagerNumber,
         manager.ManagerAllContacts, manager.ManagerPersonalContact, manager.ManagedAgents
         ); ;
    }

    public static ManagerPersonalContact Create(Contact contact, Manager manager)
    {
        return new ManagerPersonalContact(contact, manager);
    }

    public static ManagerPersonalContact Update(Contact newContact, Manager newManager)
    {
        return new ManagerPersonalContact(newContact, newManager);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(ManagerPersonalContact managerPersonalContact)
    {
        managerPersonalContact.IsDeleted = false;
    }


    private void ValidateManagerPersonalContact(Contact contact, Manager manager)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
        if (manager == null)
        {
            throw new ArgumentNullException(nameof(manager), "Manager is required.");
        }

    }






}
