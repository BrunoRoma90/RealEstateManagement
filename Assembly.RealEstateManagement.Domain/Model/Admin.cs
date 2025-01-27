using System.Net.Http.Headers;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Admin : Employee , IAdmin
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

    //Create All
    public Agent CreateAgent(Agent agent)
    {
        return Agent.CreateAgent(agent.Id, agent.Name, agent.Account, agent.Contact, agent.Address, agent.EmployeeNumber,
            agent.AgentNumber, agent.ManagedProperties, agent.Visits, agent.Contacts, agent.Manager);
    }
    public AdministrativeUsers CreateAdministrativeUser(AdministrativeUsers adminUser)
    {
        return AdministrativeUsers.CreateAdministrativeUser(adminUser.Name, adminUser.Account, adminUser.Contact, adminUser.Address, adminUser.EmployeeNumber,
            adminUser.AdministrativeNumber, adminUser.Clients, adminUser.Employees);
    }
    public Manager CreateManager(Manager manager)
    {
        return Manager.CreateManager(manager.Name, manager.Account, manager.Contact, manager.Address,
            manager.EmployeeNumber, manager.ManagerNumber, manager.ManagedAgents);
    }
    public Client CreateClient(Client client)
    {
        return Client.CreateClient(client.Name, client.Account, client.Contact, client.IsRegistered, client.FavoriteProperties, client.Ratings, client.Comments, client.Visits);
    }

    //Update All
    public void UpdateAgent(Agent agent)
    {
        agent.UpdateAgent(agent.Id, agent.AgentNumber, agent.Name, agent.Account, agent.Contact, agent.Address, agent.EmployeeNumber,
            agent.ManagedProperties, agent.Visits, agent.Contacts);
    }
    public void UpdateAdministrativeUsers(AdministrativeUsers administrativeUser)
    {
        administrativeUser.UpdateAdministrativeUser(administrativeUser.Name, administrativeUser.Account,administrativeUser.Contact,administrativeUser.Address,
            administrativeUser.EmployeeNumber, administrativeUser.AdministrativeNumber, administrativeUser.Clients, administrativeUser.Employees);
    }
    public void UpdateManager(Manager manager)
    {
        manager.UpdateManager(manager);
    }
    public void UpdateClient(Client client)
    {
        client.UpdateClient(client.Name, client.Account, client.Contact, client.IsRegistered, client.FavoriteProperties, client.Ratings, client.Comments, client.Visits);
    }

}   
    

public interface IAdmin
{
    public int AdminNumber { get; }
    public  Agent CreateAgent(Agent agent);
    public AdministrativeUsers CreateAdministrativeUser(AdministrativeUsers adminUsers);
    public Manager CreateManager(Manager manager);

    public Client CreateClient(Client client);

    public void UpdateAgent(Agent agent);
    public void UpdateAdministrativeUsers(AdministrativeUsers administrativeUsers);
    public void UpdateManager(Manager manager);

    public void UpdateClient(Client client);
    //void DeleteEmployee(int employeeId);
    //Employee GetEmployee(int employeeId);



    //void CreateProperty(Property property);
    //void UpdatePorperty(int propertyId, Property updatedProperty);
    //void DeleteProperty(int propertyId);
    //List<Property> GetAllProperties();


    //List<Visit> GetAllAppointments();
    //void CreateAppointment(Visit visit, Employee employee);
    //void DeleteAppointment(Visit visit, Employee employee);
}
