
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
        ContactType = contactType;
        Value = value;
    }


}

