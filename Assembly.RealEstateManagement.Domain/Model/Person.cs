using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Contact Contact { get; private set; }

    protected Person(Name name, Account account, Contact contact)
    {
        Name = name;
        Account = account;
        Contact = contact;
    }


}

public class Employee : Person
{

    public Address Address { get; private set; }

    private Employee(Name name, Account account, Contact contact, Address address) : base(name, account, contact)
    {

        Address = address;

    }
}

public class Client : Person
{
    private Client(Name name, Account account, Contact contact) : base(name, account, contact)
    {

    }
}
