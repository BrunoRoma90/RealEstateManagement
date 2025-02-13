using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public Manager Manager { get; private set; }

    private ManagerAllContact() { }

    private ManagerAllContact(Name name, Contact contact, Manager manager):this()
    {
        ValidateManagerAllContact(name, contact, manager);
        Name = name;
        Contact = contact;
        Manager = manager;
        Created = DateTime.Now;
        Updated = DateTime.Now;
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
