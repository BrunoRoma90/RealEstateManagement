namespace Assembly.RealEstateManagement.Services.Dtos;

public class CreateAdministrativeUserPersonalContactDto 
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AdministrativeUserDto AdministrativeUser { get; set; }
}