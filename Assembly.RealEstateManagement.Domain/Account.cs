using System.Text.RegularExpressions;

namespace Assembly.RealEstateManagement.Domain;

public class Account
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    //public string PasswordHash { get; set; }
    //public string PasswordSalt { get; set; }

    private Account() 
    {
        Email = string.Empty;
        Password = string.Empty;
    }

    private Account(string email, string password)
    {
        ValidateEmail(email);
        ValidatePassword(password);
        Email = email;
        Password = password;
    }


    public static Account Create(string email, string password)
    {
        return new Account(email,password);
    }
    public void UpdateEmail(string newEmail)
    {
        ValidateEmail(newEmail);
        Email = newEmail;
    }
    public void UpdatePasswordl(string newPassword)
    {
        ValidatePassword(newPassword);
        Password = newPassword;
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
        if(string.IsNullOrEmpty(password)) 
        {
            throw new ArgumentNullException("Password is required"); 
        }
        if(password.Length < 5)
        {
            throw new ArgumentException("Password must be at least 8 characters long");
        }
    }

}

