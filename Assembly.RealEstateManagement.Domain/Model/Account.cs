using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Account : AuditableEntity<int>
{
    public string Email { get; private set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }


    private Account() { }

    private Account(int id, string email, string password) : this()
    {
        Id = id;
        Email = email;
        SetPassword(password);

    }

    private Account(string email, string password): this()
    {
        ValidateEmail(email);
        Email = email;
        SetPassword(password);
    }

    public static Account Create(string email, string password)
    {
        return new Account(email, password);
    }

    public static Account Update(int id,string newEmail, string newPassword)
    {
        var account = new Account();
        account.Id = id;
        account.UpdateEmail(newEmail);
        account.SetPassword(newPassword);
        return account;
    }

    public void Update(string newEmail, string newPassword)
    {

        UpdateEmail(newEmail);
        SetPassword(newPassword);
    }



    public void UpdateEmailAndPassword(string newEmail, string newPassword)
    {
        UpdateEmail(newEmail);
        SetPassword(newPassword);
    }


    private void UpdateEmail(string newEmail)
    {
        ValidateEmail(newEmail);
        Email = newEmail;
    }
    private void SetPassword(string password)
    {
        ValidatePassword(password);
        CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }


    public bool VerifyPassword(string password)
    {
        return VerifyPasswordHash(password, PasswordHash, PasswordSalt);
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
            
            var tempPassword = Guid.NewGuid().ToString("N").Substring(0, 8); // Gera uma senha de 8 caracteres
            throw new ArgumentNullException("Password is required. A temporary password could be generated: " + tempPassword);
        }
        if (password.Length < 8) 
        {
            throw new ArgumentException("Password must be at least 8 characters long");
        }
    }


    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var hmac = new HMACSHA512(storedSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(storedHash);
    }
}

