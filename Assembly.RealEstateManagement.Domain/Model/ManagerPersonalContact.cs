using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class ManagerPersonalContact : AuditableEntity<int>
{
    public Contact Contact { get; set; }
    public Manager Manager { get; set; }



    public ManagerPersonalContact()
    {

    }
}
