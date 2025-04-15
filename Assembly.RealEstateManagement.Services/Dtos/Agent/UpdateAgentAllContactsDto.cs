namespace Assembly.RealEstateManagement.Services.Dtos.Agent;

public class UpdateAgentAllContactsDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }

    public string[]? MiddleNames { get; set; }
    public string? LastName { get; set; }

    public string? ContactType { get; set; }
    public string? Value { get; set; }
}
