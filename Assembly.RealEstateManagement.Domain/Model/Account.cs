using System.Text.RegularExpressions;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Account : AuditableEntity<int>
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    private Account() { }

}

