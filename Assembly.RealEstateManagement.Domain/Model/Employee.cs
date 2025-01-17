
namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Employee : Person
{

    public int EmployeeNumber { get; protected set; }
    public Address Address { get; private set; }

    protected Employee()
    {
        EmployeeNumber = 0;
        Address = Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty);
    }
    protected Employee(Name name, Account account, Contact contact, Address address, int employeeNumber) : base(name, account, contact)
    {
        ValidateEmployee(address, employeeNumber);
        EmployeeNumber = employeeNumber;
        Address = address;

    }

    public void UpdateEmployee(Address address, int newEmployeeNumber)
    {
        ValidateEmployee(address, newEmployeeNumber);
        Address.UpdateAddress(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        EmployeeNumber = newEmployeeNumber;
    }

    public void UpdateEmployeeNumber(int newEmployeeNumber)
    {
        ValidateEmployeeNumber(newEmployeeNumber);

        EmployeeNumber = newEmployeeNumber;
    }
    private void ValidateEmployeeNumber(int employeeNumber) 
    {
        if (employeeNumber <= 0)
        {
            throw new ArgumentNullException(nameof(employeeNumber), "Employee Number must be greater than zero.");
        }
    }

    private void ValidateEmployee(Address address, int employeeNumber)
    {

        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
        if (employeeNumber <= 0)
        {
            throw new ArgumentNullException(nameof(employeeNumber), "Employee Number must be greater than zero.");
        }


    }
}


