namespace Assembly.RealEstateManagement.Domain.Model;

public class Admin : Employee
{
    public int AdminNumber { get; private set; }
    private Admin()
    {
        AdminNumber = 0;
    }
    private Admin(Name name, Account account, Contact contact, Address address, int employeeNumber) 
        : base(name, account, contact, address, employeeNumber)
    { 
        AdminNumber = 0;
    }
    private Admin(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber) 
        : this(name, account, contact, address, employeeNumber)
    {
        ValidateAdminInfo(adminNumber,name,account,contact,address);
        AdminNumber = adminNumber;
    }
    public static Admin CreateAdmin(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber)
    {
        return new Admin(name, account, contact, address, employeeNumber, adminNumber);
    }

    public void UpdateAdmin(Admin admin)
    {
        if (admin == null)
        {
            throw new ArgumentNullException(nameof(admin), "Name is required.");
        }
        ValidateAdminInfo(admin.AdminNumber, admin.Name, admin.Account, admin.Contact, admin.Address);
        AdminNumber = admin.AdminNumber;
        Name.UpdateName(admin.Name.FirstName, admin.Name.MiddleNames, admin.Name.LastName); 
        Account.UpdateEmailAndPassword(admin.Account.Email, admin.Account.Password);
        Contact.UpdateContact(admin.Contact);
        Address.UpdateAddress(admin.Address.Street, admin.Address.Number, admin.Address.PostalCode, admin.Address.City, admin.Address.Country);
    }


  

    private void ValidateAdminInfo(int adminNumber, Name name, Account account, Contact contact, Address address)
    {
        if (adminNumber <= 0)
        {
            throw new ArgumentException(nameof(adminNumber), "Agent number must be greater than zero.");
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account is required.");
        }
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
    
    }




}


