namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUser : Employee
{
    public int AdministrativeNumber { get; private set; }

    public List<AdministrativeUserPersonalContact> AdministrativeUsersPersonalContact { get; private set; }

    public List<AdministrativeUserAllContact> AdministrativeUsersAllContact { get; private set; }
    public bool IsAdmin { get; private set; }

    private AdministrativeUser() { }

    private AdministrativeUser(int id, Name name, Account account, Address address, int employeeNumber,int administrativeNumber,
        List<AdministrativeUserPersonalContact> administrativeUsersPersonalContact,
        List<AdministrativeUserAllContact> administrativeUsersAllContact,
        bool isAdmin): base(employeeNumber, name, account, address)
    {
        Id = id;
        AdministrativeNumber = administrativeNumber;
        AdministrativeUsersPersonalContact = administrativeUsersPersonalContact;
        AdministrativeUsersAllContact = administrativeUsersAllContact;
        IsAdmin = isAdmin;
    }
}


