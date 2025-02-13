using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUserPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; private set; }

    public AdministrativeUser AdministrativeUser { get; private set; }

    private AdministrativeUserPersonalContact()
    {}


    private AdministrativeUserPersonalContact(int id, Contact contact, AdministrativeUser administrativeUser):this()
    {
        ValidateAdministrativeUserPersonalContact(contact, administrativeUser);
        Contact = contact;
        AdministrativeUser = administrativeUser;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private AdministrativeUserPersonalContact(Contact contact, AdministrativeUser administrativeUser) : this()
    {
        Contact = Contact.Create(contact.ContactType, contact.Value);
        AdministrativeUser = AdministrativeUser.Create(administrativeUser.Name, administrativeUser.Account,
           administrativeUser.Address, administrativeUser.EmployeeNumber, administrativeUser.AdministrativeNumber,
           administrativeUser.AdministrativeUsersAllContact, administrativeUser.AdministrativeUsersPersonalContact);
    }

    public static AdministrativeUserPersonalContact Create(Contact contact, AdministrativeUser administrativeUser)
    {
        return new AdministrativeUserPersonalContact(contact,administrativeUser);
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


