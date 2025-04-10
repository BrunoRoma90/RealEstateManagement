using System.Diagnostics;
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

    public static Account Update(int id,string newEmail, string newPassword)
    {
        return new Account(id ,newEmail, newPassword);
    }

    public void Update(string newEmail, string newPassword)
    {

        Email = newEmail;
        Password = newPassword;
    }



    public void UpdateEmailAndPassword(string newEmail, string newPassword)
    {
        UpdateEmail(newEmail);
        UpdatePasswordl(newPassword);
        Email = newEmail;
        Password = newPassword;

    }
    private void UpdateEmail(string newEmail)
    {
        ValidateEmail(newEmail);
        Email = newEmail;
    }
    private void UpdatePasswordl(string newPassword)
    {
        ValidatePassword(newPassword);
        Password = newPassword;
    }



    public static void Restore(Account account)
    {
        account.IsDeleted = false;
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

