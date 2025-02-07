namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUser : Employee
{
    public int AdministrativeNumber { get; private set; }

    public List<AdministrativeUserPersonalContact> AdministrativeUsersPersonalContact { get; private set; }

    public List<AdministrativeUserAllContact> AdministrativeUsersAllContact { get; private set; }
    public bool IsAdmin { get; private set; }

    private AdministrativeUser()
    {

    }
}


