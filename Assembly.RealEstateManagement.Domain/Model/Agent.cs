namespace Assembly.RealEstateManagement.Domain.Model;

public class Agent : Employee
{
    public int AgentNumber { get; private set; }

    public List<AgentPersonalContact> AgentPersonalContact { get; private set; }

    public List<Property> ManagedProperty { get; private set; }

    public List<AgentAllContact> AgentAllContact { get; private set; }

    public Manager Manager { get; private set; }
    private Agent(){}

    private Agent(int id, int employeeNumber, Name name, Account account, Address address,
        int agentNumber,
        List<AgentPersonalContact> agentPersonalContact, 
        List<Property> managedProperty, 
        List<AgentAllContact> agentAllContact,
        Manager manager) :base(employeeNumber, name, account, address)
    {
        ValidateAgent(id, agentNumber, employeeNumber, agentPersonalContact, managedProperty, agentAllContact, manager);
        Id = id;
        AgentNumber = agentNumber;
        AgentPersonalContact = agentPersonalContact;
        ManagedProperty = managedProperty;
        AgentAllContact = agentAllContact;
        Manager = manager;
    }

    

    private void ValidateAgent(int id, int agentNumber,int employeeNumber, List<AgentPersonalContact> agentPersonalContact,
        List<Property> managedProperty, List<AgentAllContact> agentAllContact, Manager manager)
    {
        if (id <= 0)
        {
            throw new ArgumentException(nameof(id), "Id must be greater than zero.");
        }
        if (employeeNumber <= 0)
        {
            throw new ArgumentException(nameof(employeeNumber), "Employee Number must be greater than zero.");
        }
        if (agentNumber <= 0)
        {
            throw new ArgumentException(nameof(agentNumber), "Agent number must be greater than zero.");
        }
        if (agentPersonalContact == null || agentPersonalContact.Count == 0)
        {
            throw new ArgumentNullException(nameof(agentPersonalContact), "Personal Contact list is required.");
        }
        if (managedProperty == null || managedProperty.Count == 0)
        {
            throw new ArgumentNullException(nameof(managedProperty), "Managed Property list is required.");
        }
        if (manager == null)
        {
            throw new ArgumentNullException(nameof(manager), "Manager is required.");
        }
    }
}


