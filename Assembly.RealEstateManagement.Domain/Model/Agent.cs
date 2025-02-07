namespace Assembly.RealEstateManagement.Domain.Model;

public class Agent : Employee
{
    public int AgentNumber { get; private set; }

    public List<AgentPersonalContact> AgentPersonalContact { get; private set; }

    public List<Property> ManagedProperty { get; private set; }

    public List<AgentAllContact> AgentAllContact { get; private set; }

    public Manager Manager { get; private set; }
    private Agent()
    {

    }

}


