namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Employee : Person
{

    public int EmployeeNumber { get; private set; }
    public Address Address { get; private set; }

    protected Employee()
    {
        EmployeeNumber = 0;
        Address = Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty);
    }
    protected Employee(Name name, Account account, Contact contact, Address address, int employeeNumber) : base(name, account, contact)
    {

        EmployeeNumber = employeeNumber;
        Address = address;

    }
}


