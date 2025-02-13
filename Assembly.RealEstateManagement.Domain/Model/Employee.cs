
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Employee : AuditableEntity<int>
{

    public int EmployeeNumber { get; protected set; }
    public Name Name { get; protected set; }
    public Account Account { get; protected set; }

    public Address Address { get; protected set; }


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


