using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }
    public Manager Manager { get; private set; }



    public ManagerPersonalContact() { }

    public ManagerPersonalContact(Contact contact, Manager manager) : this()
    {
        Contact = contact;
        Manager = manager;
    }







}
