using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Contact Contact { get; private set; }

    protected Person()
    {
        Name = null;
        Account = null;
        Contact = null;
    }
    protected Person(Name name, Account account, Contact contact)
    {
        Name = name;
        Account = account;
        Contact = contact;
    }


}


