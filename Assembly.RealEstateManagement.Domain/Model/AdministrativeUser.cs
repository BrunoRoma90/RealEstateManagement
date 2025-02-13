using System.ComponentModel;

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
        ValidateAdministrativeUsers(administrativeNumber, employeeNumber, administrativeUsersPersonalContact, administrativeUsersAllContact);
        Id = id;
        AdministrativeNumber = administrativeNumber;
        AdministrativeUsersPersonalContact = administrativeUsersPersonalContact;
        AdministrativeUsersAllContact = administrativeUsersAllContact;
        IsAdmin = isAdmin;
    }

    private void ValidateAdministrativeUsers(int administrativeNumber, int employeeNumber,
        List<AdministrativeUserPersonalContact> administrativeUsersPersonalContact,
        List<AdministrativeUserAllContact> administrativeUsersAllContact)
    {
        if (administrativeNumber <= 0)
        {
            throw new ArgumentException(nameof(administrativeNumber), "Administrative number must be greater than zero.");
        }
        if (employeeNumber <= 0)
        {
            throw new ArgumentException(nameof(employeeNumber), "Employee number must be greater than zero.");
        }
        if (administrativeUsersPersonalContact == null || administrativeUsersPersonalContact.Count == 0)
        {
            throw new ArgumentNullException(nameof(administrativeUsersPersonalContact), "Personal Contacts list is required.");
        }
        if (administrativeUsersAllContact == null || administrativeUsersAllContact.Count == 0)
        {
            throw new ArgumentNullException(nameof(administrativeUsersAllContact), "All contacts list is required.");
        }
    }
}


