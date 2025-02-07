
using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Contact
{
    public string Value { get; private set; }
    public ContactType ContactType { get; private set; }

    private Contact()
    {

    }

}

