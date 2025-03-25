namespace Assembly.RealEstateManagement.Services.Dtos;

public class CreateManagerPersonalContacts
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public ManagerDto Manager { get; set; }
}
