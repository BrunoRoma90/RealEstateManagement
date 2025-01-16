using System.Diagnostics;

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
        //ValidateEmployee(name, account, contact, address, employeeNumber);
        UpdateEmployeeNumber(employeeNumber);
        EmployeeNumber = employeeNumber;
        Address = address;

    }

    protected int UpdateEmployeeNumber(int newEmployeeNumber)
    {
        if (newEmployeeNumber <= 0)
        {
            throw new ArgumentException("Employee number must be greater than zero.", nameof(newEmployeeNumber));
        }

        return EmployeeNumber = newEmployeeNumber;
    }


    //public static Employee CreateEmployee(Employee employee)
    //{
    //    return new Employee(employee.Name, employee.Account, employee.Contact, employee.Address, employee.EmployeeNumber);
    //}

    //private void ValidateEmployee(Name name, Account account, Contact contact, Address address, int employeeNmeber)
    //{
    //    if (name == null)
    //    {
    //        throw new ArgumentNullException(nameof(name), "Name is required.");
    //    }
    //    if (account == null)
    //    {
    //        throw new ArgumentNullException(nameof(account), "Account is required.");
    //    }
    //    if (contact == null)
    //    {
    //        throw new ArgumentNullException(nameof(contact), "Contact is required.");
    //    }
    //    if (address == null)
    //    {
    //        throw new ArgumentNullException(nameof(name), "Name is required.");
    //    }
    //    if (employeeNmeber <= 0)
    //    {
    //        throw new ArgumentNullException(nameof(employeeNmeber), "Employee Number must be greater than zero.");
    //    }

    //}
}


