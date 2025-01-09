
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain;

public class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }


    protected Person(Name name, Account account)
    {
        Name = name;
        Account = account;
    }


}

public class Employee : Person
{
    public Contact Contact { get; private set; }
    public Address Address { get; private set; }

    private Employee(Name name, Account account, Contact contact, Address address): base(name,account)
    {
        
        Contact = contact;
        Address = address;
        
    }
}

