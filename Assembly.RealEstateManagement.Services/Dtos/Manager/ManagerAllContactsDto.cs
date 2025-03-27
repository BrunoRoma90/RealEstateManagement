namespace Assembly.RealEstateManagement.Services.Dtos.Manager;

public class ManagerAllContactsDto
{
    public string FirstName { get; set; }

    public string[] MiddleNames { get; set; }
    public string LastName { get; set; }

    public string ContactType { get; set; }
    public string Value { get; set; }

    public ManagerDto Manager { get; set; }
}
