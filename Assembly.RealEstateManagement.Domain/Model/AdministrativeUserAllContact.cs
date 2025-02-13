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

    private AdministrativeUserAllContact(Name name, Contact contact, AdministrativeUser administrativeUser) : this()
    {
        ValidateAdministrativeUserAllContact(name, contact, administrativeUser);
        Name = name;
        Contact = contact;
        AdministrativeUser = administrativeUser;
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


