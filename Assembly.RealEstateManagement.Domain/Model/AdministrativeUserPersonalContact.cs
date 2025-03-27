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

    }

    private AdministrativeUserPersonalContact(Contact contact, AdministrativeUser administrativeUser) : this()
    {
        Contact = Contact.Create(contact.ContactType, contact.Value);
        AdministrativeUser = administrativeUser;
    }

    public static AdministrativeUserPersonalContact Create(Contact contact, AdministrativeUser administrativeUser)
    {
        return new AdministrativeUserPersonalContact(contact,administrativeUser);
    }

    public static AdministrativeUserPersonalContact Update(Contact newContact, AdministrativeUser newAdministrativeUser)
    {
        return new AdministrativeUserPersonalContact(newContact,newAdministrativeUser);
    }


    public static void Restore(AdministrativeUserPersonalContact administrativeUserPersonalContact)
    {
        administrativeUserPersonalContact.IsDeleted = false;
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


