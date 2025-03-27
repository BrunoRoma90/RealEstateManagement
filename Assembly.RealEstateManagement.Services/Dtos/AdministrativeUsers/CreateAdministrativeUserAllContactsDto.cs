namespace Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;

public class CreateAdministrativeUserAllContactsDto
{
    public string FirstName { get; set; }

    public string[] MiddleNames { get; set; }
    public string LastName { get; set; }

    public string ContactType { get; set; }
    public string Value { get; set; }

    public AdministrativeUserDto AdministrativeUser{ get; set; }
}
