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
        ValidateAdministrativeUserPersonalContact(contact, administrativeUser);
        Contact = contact;
        AdministrativeUser = administrativeUser;
    }

    private void ValidateAdministrativeUserPersonalContact(Contact contact, AdministrativeUser administrativeUser)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
        if (administrativeUser == null)
        {
            throw new ArgumentNullException(nameof(administrativeUser), "Administrative User is required.");
        }

    }
}


