namespace Assembly.RealEstateManagement.Services.Dtos.Common;

public class CreateVisitDto
{
    public int ClientId { get; set; }
    public int PropertyId { get; set; }
    public int AgentId { get; set; }
    public DateTime VisitDate { get; set; }
    public string Notes { get; set; }
}
