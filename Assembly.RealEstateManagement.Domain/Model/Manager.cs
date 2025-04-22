namespace Assembly.RealEstateManagement.Domain.Model;

public class Manager : Employee
{
    public int ManagerNumber { get; private set; }

    public List<ManagerPersonalContact> ManagerPersonalContact { get; private set; }

    public List<ManagerAllContact> ManagerAllContacts { get; private set; }

    public List<Agent> ManagedAgents { get; private set; }

    private Manager() { }

    private Manager(int id,int employeeNumber, Name name, Account account, Address address,
        int managerNumber,
        List<ManagerPersonalContact> managerPersonalContact,
        List<ManagerAllContact> managerAllContacts,
        List<Agent> managedAgents):base(employeeNumber, name, account, address)
    {
        ValidateManager(managerNumber, employeeNumber, managerPersonalContact, managerAllContacts);
        Id = id;
        EmployeeNumber = employeeNumber;
        Name = name;
        Account = account;
        Address = address;
        ManagerNumber = managerNumber;
        ManagerPersonalContact = managerPersonalContact;
        ManagerAllContacts = managerAllContacts;
        ManagedAgents = managedAgents;

    }

    private Manager(int employeeNumber, Name name, string email, string password, Address address,
       int managerNumber,
       List<ManagerPersonalContact> managerPersonalContact,
       List<ManagerAllContact> managerAllContacts,
       List<Agent> managedAgents) : base(employeeNumber, name, null, address)
    {
        ValidateManager(managerNumber, employeeNumber, managerPersonalContact, managerAllContacts);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Account = Account.Create(email, password);
        Address = Address.Create(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        EmployeeNumber = employeeNumber;
        ManagerNumber = managerNumber;
        ManagerPersonalContact = managerPersonalContact;
        ManagerAllContacts = managerAllContacts;
        ManagedAgents = managedAgents;
     
    }


    public static Manager Create(int emplyeeNumber, Name name, string email, string password, Address address, int managerNumber,
        List<ManagerAllContact> managerAllContacts, List<ManagerPersonalContact> managerPersonalContacts, List<Agent> managedAgents)
    {
        
        return new Manager(emplyeeNumber, name, email, password, address, managerNumber, managerPersonalContacts, managerAllContacts, managedAgents);
    }
    //public static Manager Update(int id, int newEmplyeeNumber, Name newName, Account newAccount, Address newAddress, int newManagerNumber,
    //   List<ManagerAllContact> newManagerAllContacts, List<ManagerPersonalContact> newManagerPersonalContacts, List<Agent> newManagedAgents)
    //{

    //    return new Manager(id, newEmplyeeNumber, newName, newAccount, newAddress, newManagerNumber, newManagerPersonalContacts, newManagerAllContacts, newManagedAgents);
    //}

    public void Update(int id, int newEmployeeNumber, Name newName, string newEmail, string newPassword, Address newAddress, int newManagerNumber,
        List<ManagerAllContact> newManagerAllContacts, List<ManagerPersonalContact> newManagerPersonalContacts, List<Agent> newManagedAgents)
    {
        Id = id;
        EmployeeNumber = newEmployeeNumber;
        Name = newName;
        Account.Update(newEmail, newPassword);
        Address = newAddress;
        ManagerNumber = newManagerNumber;
        ManagerPersonalContact = newManagerPersonalContacts;
        ManagerAllContacts = newManagerAllContacts;
        ManagedAgents = newManagedAgents;
    }



    public static void Restore(Manager manager)
    {
        manager.IsDeleted = false;
    }

    private void ValidateManager(int managerNumber, int employeeNumber,
        List<ManagerPersonalContact> managerPersonalContact,
        List<ManagerAllContact> managerAllContact)
    {
     
        if (employeeNumber <= 0)
        {
            throw new ArgumentException(nameof(employeeNumber), "Employee Number must be greater than zero.");
        }
        if (managerNumber <= 0)
        {
            throw new ArgumentException(nameof(managerNumber), "Manager number must be greater than zero.");
        }
        //if (managerPersonalContact == null || managerPersonalContact.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(managerPersonalContact), "Personal Contact list is required.");
        //}
        //if (managerAllContact == null || managerAllContact.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(managerAllContact), "Manager all contact list is required.");
        //}
    }
}
