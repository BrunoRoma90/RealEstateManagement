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
        Name = name;
        Contact = contact;
        Manager = manager;
    }
}
