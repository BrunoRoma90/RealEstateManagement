using System.ComponentModel;
using System.Data;
using System.IO.Pipes;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Xml.Linq;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public abstract class Person : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }

    public Contact Contact { get; private set; }

    protected Person()
    {
        Name = null;
        Account = null;
        Contact = null;
    }
    protected Person(Name name, Account account, Contact contact)
    {
        Name = name;
        Account = account;
        Contact = contact;
    }


}

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    public Client Client { get; private set; }

    private Rating()
    {
        Value = 0;
        Property = null;
        Client = null;
    }
    private Rating(double value, Property property, Client client)
    {
        Value = value;
        Property = property;
        Client = client;
    }
}

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }
    public Client Client { get; private set; }

    private Comment()
    {
        Text = string.Empty;
        Property = null;
        Client = null;
    }
    private Comment(string text, Property property, Client client)
    {
        Text = text;
        Property = property;
        Client = client;
    }
}

public class FavoriteProperties : AuditableEntity<int>
{
    public Client Client { get; private set; }
    public Property Property { get; private set; }

    private FavoriteProperties() 
    {
        Client = null;
        Property = null;
    }

    private FavoriteProperties(Client client, Property property)
    {
        Client = client;
        Property = property;
    }
}
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


    public void ManageUser(Employee employee, Name newName, Account newAccount, Contact newContact)
    { 
        (employee);
        e(newName, newAccount, newContact); }

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


