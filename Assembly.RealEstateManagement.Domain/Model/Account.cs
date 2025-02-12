using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Account : AuditableEntity<int>
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    private Account() { }

    private Account(int id, string email, string password) : this()
    {
        Id = id;
        Email = email;
        Password = password;
    }

    private Account(string email, string password): this()
    {
        Email = email;
        Password = password;
    }

    public static Account Create(string email, string password)
    {
        return new Account(email, password);
    }




}

