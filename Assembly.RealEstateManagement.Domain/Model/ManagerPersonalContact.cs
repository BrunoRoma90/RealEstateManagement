using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }
    public Manager Manager { get; private set; }



    public ManagerPersonalContact() { }

    public ManagerPersonalContact(Contact contact, Manager manager) : this()
    {
        ValidateManagerPersonalContact(contact,manager);
        Contact = contact;
        Manager = manager;
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
