using System.Diagnostics;
using System.Runtime.CompilerServices;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Contact Contact { get; private set; }

    protected Person()
    {
        Name = Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty);
        Account = Account.Create(string.Empty, string.Empty);
        Contact = Contact.CreateContact(default, string.Empty);
    }
    protected Person(Name name, Account account, Contact contact)
    {
        ValidatePerson(name, account, contact);
        Name = name;
        Account = account;
        Contact = contact;
    }

    private void ValidatePerson(Name name, Account account, Contact contact)
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account is required.");
        }
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
    }

    public void UpdatePerson(Name name, Account account, Contact contact)
    {
        ValidatePerson(name, account, contact);
        Name = name;
        Account = account;
        Contact = contact;

    }

}


