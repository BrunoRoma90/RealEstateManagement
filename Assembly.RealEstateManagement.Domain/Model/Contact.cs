
using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Contact : AuditableEntity<int>
{
    public ContactType ContactType { get; private set; }

    public string Value { get; private set; }

    private Contact()
    {
        ContactType = default;
        Value = string.Empty;
    }

    private Contact(ContactType contactType, string value) :this()
    {
        ValidateContact(contactType, value);
        ContactType = contactType;
        Value = value;
    }

    public static Contact CreateContact(ContactType contactType, string value)
    {
        return new Contact(contactType, value);
    }

    public void UpdateContact(Contact newContact)
    {
        ValidateContact(newContact.ContactType, newContact.Value);
        ContactType = newContact.ContactType;
        Value = newContact.Value;
    }
    private void ValidateContact(ContactType contactType, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("Contact value is required.");
        }
        switch (contactType)
        {
            case ContactType.Email:
                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ArgumentException("Email is not in a valid format.");
                }
                break;

            case ContactType.Phone:
                if (!Regex.IsMatch(value, @"^\+?\d{10,15}$"))
                {
                    throw new ArgumentException("Phone number is not in a valid format.");
                }
                break;

            case ContactType.Mobile:
                if (!Regex.IsMatch(value, @"^\+?\d{10,15}$"))
                {
                    throw new ArgumentException("Mobile number is not in a valid format.");
                }
                break;

            default: throw new ArgumentException("Unsupported contact type.");



        }
    }
}

