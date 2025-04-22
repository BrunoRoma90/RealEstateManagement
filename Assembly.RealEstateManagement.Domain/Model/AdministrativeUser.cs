

namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUser : Employee
{
    public int AdministrativeNumber { get; private set; }

    public List<AdministrativeUserPersonalContact> AdministrativeUsersPersonalContact { get; private set; }

    public List<AdministrativeUserAllContact> AdministrativeUsersAllContact { get; private set; }
    public bool IsAdmin { get; private set; }

    private AdministrativeUser() { }

    private AdministrativeUser(int id, Name name, string email, string password, Address address, int employeeNumber,int administrativeNumber,
        List<AdministrativeUserPersonalContact> administrativeUsersPersonalContact,
        List<AdministrativeUserAllContact> administrativeUsersAllContact,
        bool isAdmin): base(employeeNumber, name, null, address)
    {
        ValidateAdministrativeUsers(administrativeNumber, employeeNumber, administrativeUsersPersonalContact, administrativeUsersAllContact);
        Id = id;
        AdministrativeNumber = administrativeNumber;
        AdministrativeUsersPersonalContact = administrativeUsersPersonalContact;
        AdministrativeUsersAllContact = administrativeUsersAllContact;
        IsAdmin = isAdmin;

    }

    private AdministrativeUser(Name name, string email, string password, Address address, int employeeNumber, int administrativeNumber,
        List<AdministrativeUserAllContact> administrativeUserAllContacts,
        List<AdministrativeUserPersonalContact> administrativeUserPersonalContacts, bool isAdmin)
    {
        ValidateAdministrativeUsers(administrativeNumber, administrativeNumber, administrativeUserPersonalContacts, administrativeUserAllContacts);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Account = Account.Create(email, password);
        Address = Address.Create(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        EmployeeNumber = employeeNumber;
        AdministrativeNumber = administrativeNumber;
        AdministrativeUsersAllContact = new List<AdministrativeUserAllContact>();
        foreach (var contact in administrativeUserAllContacts)
        {
            AdministrativeUsersAllContact.Add(AdministrativeUserAllContact.Create(contact.Name, contact.Contact, this));
        }
        AdministrativeUsersPersonalContact = new List<AdministrativeUserPersonalContact>();
        foreach (var contact in administrativeUserPersonalContacts)
        {
            AdministrativeUsersPersonalContact.Add(AdministrativeUserPersonalContact.Create(contact.Contact, this));
        }
        IsAdmin = isAdmin;
    }

    public static AdministrativeUser Create(Name name, string email, string password, Address address, int employeeNumber, int administrativeNumber,
       List<AdministrativeUserAllContact> administrativeUserAllContacts,
       List<AdministrativeUserPersonalContact> userPersonalContacts) 
    {
        
        return new AdministrativeUser(name, email, password, address, employeeNumber, administrativeNumber, administrativeUserAllContacts,
            userPersonalContacts, false );
    }


    public void Update(int id,Name newName, string newEmail, string newPassword, Address newAddress, int newEmployeeNumber, int newAdministrativeNumber,
       List<AdministrativeUserAllContact> newAdministrativeUserAllContacts,
       List<AdministrativeUserPersonalContact> newAdministrativeUserPersonalContacts) 
    {
        Id = id;
        Name = newName;
        Account.Update(newEmail, newPassword);
        Address = newAddress;
        EmployeeNumber = newEmployeeNumber;
        AdministrativeNumber = newAdministrativeNumber;
        AdministrativeUsersPersonalContact = newAdministrativeUserPersonalContacts;
        AdministrativeUsersAllContact = newAdministrativeUserAllContacts;



    }

    //public static AdministrativeUser Update(Name newName, Account newAccount, Address newAddress, int newEmployeeNumber, int newAdministrativeNumber,
    //   List<AdministrativeUserAllContact> newAdministrativeUserAllContacts,
    //   List<AdministrativeUserPersonalContact> newUserPersonalContacts)
    //{
    //    return new AdministrativeUser(newName, newAccount, newAddress, newEmployeeNumber, newAdministrativeNumber, newAdministrativeUserAllContacts,
    //        newUserPersonalContacts, false);
    //}



    public static void Restore(AdministrativeUser administrativeUser)
    {
        administrativeUser.IsDeleted = false;
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
        //if (administrativeUsersPersonalContact == null || administrativeUsersPersonalContact.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(administrativeUsersPersonalContact), "Personal Contacts list is required.");
        //}
        //if (administrativeUsersAllContact == null || administrativeUsersAllContact.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(administrativeUsersAllContact), "All contacts list is required.");
        //}
    }
}


