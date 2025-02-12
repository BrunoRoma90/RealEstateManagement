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
        Id = id;
        AgentNumber = agentNumber;
        AgentPersonalContact = agentPersonalContact;
        ManagedProperty = managedProperty;
        AgentAllContact = agentAllContact;
        Manager = manager;
    }
}


