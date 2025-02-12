using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUserAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public AdministrativeUser AdministrativeUser { get; private set; }

    private AdministrativeUserAllContact() { }

    private AdministrativeUserAllContact(Name name, Contact contact, AdministrativeUser administrativeUser):this()
    {
        Name = name;
        Contact = contact;
        AdministrativeUser = administrativeUser;
    }
}


