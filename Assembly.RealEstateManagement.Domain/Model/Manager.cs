using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Manager : Employee
{
    public int ManagerNumber { get; private set; }

    public List<ManagerPersonalContact> ManagerPersonalContact { get; set; }

    public List<ManagerAllContact> ManagerAllContacts { get; set; }

    public List<Agent> ManagedAgents { get; set; }

    public Manager() { }
}
