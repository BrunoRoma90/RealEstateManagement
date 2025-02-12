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
        ManagerNumber = managerNumber;
        ManagerPersonalContact = managerPersonalContact;
        ManagerAllContacts = managerAllContacts;
        ManagedAgents = managedAgents;
    }
}
