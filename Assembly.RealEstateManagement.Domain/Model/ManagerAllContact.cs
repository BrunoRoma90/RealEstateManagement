using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public Manager Manager { get; private set; }

    private ManagerAllContact() { }

    private ManagerAllContact(int id,Name name, Contact contact, Manager manager):this()
    {
        ValidateManagerAllContact(name, contact, manager);
        Name = name;
        Contact = contact;
        Manager = manager;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private ManagerAllContact(Name name, Contact contact, Manager manager)
    {
        ValidateManagerAllContact(name, contact, manager);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        Manager = Manager.Create(manager.EmployeeNumber, manager.Name, manager.Account,
           manager.Address, manager.ManagerNumber,
           manager.ManagerAllContacts, manager.ManagerPersonalContact, manager.ManagedAgents
           );
    }

    public static ManagerAllContact Create(Name name, Contact contact, Manager manager)
    {
        return new ManagerAllContact(name, contact, manager);
    }

    public static ManagerAllContact Update(Name newName, Contact newContact, Manager newManager)
    {
        return new ManagerAllContact(newName, newContact, newManager);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(ManagerAllContact managerAllContact)
    {
        managerAllContact.IsDeleted = false;
    }
    private void ValidateManagerAllContact(Name name, Contact contact, Manager manager)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
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
