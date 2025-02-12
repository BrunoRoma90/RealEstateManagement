using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUserPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }

    public AdministrativeUser AdministrativeUser { get; private set; }

    private AdministrativeUserPersonalContact()
    {}


    private AdministrativeUserPersonalContact(Contact contact, AdministrativeUser administrativeUser):this()
    {
        Contact = contact;
        AdministrativeUser = administrativeUser;
    }
}


