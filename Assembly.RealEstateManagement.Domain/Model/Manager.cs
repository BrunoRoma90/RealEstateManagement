using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Manager : Employee
{
    public int ManagerNumber { get; private set; }

    public List<ManagerPersonalContact> ManagerPersonalContact { get; private set; }

    public List<ManagerAllContact> ManagerAllContacts { get; private set; }

    public List<Agent> ManagedAgents { get; private set; }

    public Manager() { }

    public Manager(int id, int employeeNumber, Name name, Account account, Address address,
        int managerNumber,
        List<ManagerPersonalContact> managerPersonalContact,
        List<ManagerAllContact> managerAllContacts,
        List<Agent> managedAgents):base(employeeNumber, name, account, address)
    {
        ValidateManager(id, managerNumber, employeeNumber, managerPersonalContact, managerAllContacts);
        Id = id;
        ManagerNumber = managerNumber;
        ManagerPersonalContact = managerPersonalContact;
        ManagerAllContacts = managerAllContacts;
        ManagedAgents = managedAgents;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private void ValidateManager(int id, int managerNumber, int employeeNumber,
        List<ManagerPersonalContact> managerPersonalContact,
        List<ManagerAllContact> managerAllContact)
    {
        if (id <= 0)
        {
            throw new ArgumentException(nameof(id), "Id must be greater than zero.");
        }
        if (employeeNumber <= 0)
        {
            throw new ArgumentException(nameof(employeeNumber), "Employee Number must be greater than zero.");
        }
        if (managerNumber <= 0)
        {
            throw new ArgumentException(nameof(managerNumber), "Manager number must be greater than zero.");
        }
        if (managerPersonalContact == null || managerPersonalContact.Count == 0)
        {
            throw new ArgumentNullException(nameof(managerPersonalContact), "Personal Contact list is required.");
        }
        if (managerAllContact == null || managerAllContact.Count == 0)
        {
            throw new ArgumentNullException(nameof(managerAllContact), "Manager all contact list is required.");
        }
    }
}
