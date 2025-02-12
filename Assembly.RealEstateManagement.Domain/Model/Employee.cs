
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Employee : AuditableEntity<int>
{

    public int EmployeeNumber { get; private set; }
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Address Address { get; private set; }


    protected Employee()
    {

    }

    protected Employee(int employeeNumber, Name name, Account account, Address address):this()
    {
        EmployeeNumber = employeeNumber;
        Name = name;
        Account = account;
        Address = address;
    }


}


