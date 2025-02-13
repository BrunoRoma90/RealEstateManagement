
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Contact
{
    public ContactType ContactType { get; private set; }
    public string Value { get; private set; }
    

    private Contact() { }

    private Contact(ContactType contactType, string value) : this()
    {
        ValidateContact(contactType, value);
        ContactType = contactType;
        Value = value;
    }

    public static Contact Create(ContactType contactType, string value)
    {
       return new Contact(contactType, value);
    }

    private void ValidateContact(ContactType contactType, string value)
    {
        if(!Enum.IsDefined(typeof(ContactType), contactType))
        {
            throw new ArgumentException("Invalid contact type.");
        }

        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException(nameof(value), "Value is required.");
        }

        switch (contactType)
        {
            case ContactType.Email:
                if (!value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Invalid email format.");
                }
                break;

            case ContactType.Phone:
            case ContactType.Mobile:
                if (!value.All(char.IsDigit) || value.Length < 9)
                {
                    throw new ArgumentException("Invalid phone or mobile number.");
                }
                break;

            case ContactType.SocialMedia:
                if (value.Length < 3)
                {
                    throw new ArgumentException("Social media username is too short.");
                }
                break;
        }

    }

}

