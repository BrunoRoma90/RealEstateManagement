using System.Diagnostics.Metrics;
using System.IO;
using Assembly.RealEstateManagement.Domain.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUserAllContact : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Contact Contact { get; private set; }

    public AdministrativeUser AdministrativeUser { get; private set; }

    private AdministrativeUserAllContact() { }

    private AdministrativeUserAllContact(int id,Name name, Contact contact, AdministrativeUser administrativeUser) : this()
    {
        ValidateAdministrativeUserAllContact(name, contact, administrativeUser);
        Id = id;
        Name = name;
        Contact = contact;
        AdministrativeUser = administrativeUser;

    }

    private AdministrativeUserAllContact(Name name, Contact contact, AdministrativeUser administrativeUser) 
    {
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Contact = Contact.Create(contact.ContactType, contact.Value);
        AdministrativeUser = administrativeUser;
    }

    public static AdministrativeUserAllContact Create(Name name, Contact contact, AdministrativeUser administrativeUser)
    {
        return new AdministrativeUserAllContact(name, contact, administrativeUser);
    }

    //public static AdministrativeUserAllContact Update(Name newName, Contact newContact, AdministrativeUser newAdministrativeUser)
    //{
    //    return new AdministrativeUserAllContact( newName, newContact, newAdministrativeUser);
    //}

    public void Update(int id, Name newName, Contact newContact) 
    {
        Id = id;
        Name = newName;
        Contact = newContact;
    }



    public static void Restore(AdministrativeUserAllContact administrativeUserAllContact)
    {
        administrativeUserAllContact.IsDeleted = false;
    }
    private void ValidateAdministrativeUserAllContact(Name name, Contact contact, AdministrativeUser administrativeUser)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
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


