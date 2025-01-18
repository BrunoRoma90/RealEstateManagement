namespace Assembly.RealEstateManagement.Domain.Model;

public class Admin : Employee /*IAdmin*/
{
    public int AdminNumber { get; private set; }

    public List<Employee> Employees { get; private set; }
    private Admin()
    {
        AdminNumber = 0;
        Employees = new List<Employee>();
    }
    private Admin(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber, List<Employee> employees) 
        : base(name, account, contact, address, employeeNumber)
    { 
        ValidateAdmin(adminNumber, employees);
        AdminNumber = adminNumber;
        Employees = employees;
    }
    
    public static Admin CreateAdmin(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber , List<Employee> employees)
    {
        return new Admin(name, account, contact, address, employeeNumber, adminNumber, employees);
    }

    public void UpdateAdmin(Admin admin)
    {
        
        ValidateAdmin(admin.AdminNumber, admin.Employees);
        AdminNumber = admin.AdminNumber;
        Employees = admin.Employees;
        EmployeeNumber = admin.EmployeeNumber;
        Name.UpdateName(admin.Name.FirstName, admin.Name.MiddleNames, admin.Name.LastName); 
        Account.UpdateEmailAndPassword(admin.Account.Email, admin.Account.Password);
        Contact.UpdateContact(admin.Contact);
        Address.UpdateAddress(admin.Address.Street, admin.Address.Number, admin.Address.PostalCode, admin.Address.City, admin.Address.Country);
    }


    public void CreateEmployee(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException(nameof(employee), "Employee is required.");
        }

       
        foreach (var existingEmployee in Employees)
        {
            if (existingEmployee.EmployeeNumber == employee.EmployeeNumber)
            {
                throw new InvalidOperationException("An employee with the same employee number already exists.");
            }
        }

        
        Employees.Add(employee);

    }

    public void UpdateEmployee(Employee employee)
    {
        ValidateEmployee(employee.EmployeeNumber, employee.Name, employee.Account, employee.Contact, employee.Address);
        UpdateEmployeeNumber(employee.EmployeeNumber);
        Name.UpdateName(employee.Name.FirstName, employee.Name.MiddleNames, employee.Name.LastName);
        Account.UpdateEmailAndPassword(employee.Account.Email, employee.Account.Password);
        Contact.UpdateContact(employee.Contact);
        Address.UpdateAddress(employee.Address.Street, employee.Address.Number, employee.Address.PostalCode, employee.Address.City, employee.Address.Country);

    }

  
    private void ValidateEmployee(int employeeNumber, Name name, Account account, Contact contact, Address address)
    {
        if (employeeNumber <= 0)
        {
            throw new ArgumentException("Employee ID must be greater than zero.", nameof(employeeNumber));
        }

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

        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
    }
    public void DeleteEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }

    public Employee GetEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }


    private void ValidateAdmin(int adminNumber, List<Employee> employees)
    {
        if (adminNumber <= 0)
        {
            throw new ArgumentException(nameof(adminNumber), "Agent number must be greater than zero.");
        }
        if (employees == null)
        {
            throw new ArgumentNullException(nameof(employees), "Employee cannot be null.");
        }
        

    }
}

public interface IAdmin
{
    public int AdminNumber { get; }
    void CreateEmployee(Employee employee);

    void UpdateEmployee(int employeeNumber, Name name, Account account, Contact contact, Address address);
    void DeleteEmployee(int employeeId);
    Employee GetEmployee(int employeeId);


    
    void CreateProperty(Property property);
    void UpdatePorperty(int propertyId, Property updatedProperty);
    void DeleteProperty(int propertyId);
    List<Property> GetAllProperties();

    
    List<Visit> GetAllAppointments();
    void CreateAppointment(Visit visit, Employee employee);
    void DeleteAppointment(Visit visit, Employee employee);
}
