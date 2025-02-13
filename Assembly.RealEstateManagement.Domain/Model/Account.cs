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
        ValidateEmail(email);
        ValidatePassword(password);
        Email = email;
        Password = password;
    }

    public static Account Create(string email, string password)
    {
        return new Account(email, password);
    }


    private void ValidateEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException("Email is required");
        }
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new ArgumentException("Email is not in a valid format");
        }

    }

    private void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("Password is required");
        }
        if (password.Length < 5)
        {
            throw new ArgumentException("Password must be at least 8 characters long");
        }
    }

}

