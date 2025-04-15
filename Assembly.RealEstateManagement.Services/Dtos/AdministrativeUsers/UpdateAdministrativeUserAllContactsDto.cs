namespace Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers
{
    public class UpdateAdministrativeUserAllContactsDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string[]? MiddleNames { get; set; }
        public string? LastName { get; set; }

        public string? ContactType { get; set; }
        public string? Value { get; set; }

    }
}
