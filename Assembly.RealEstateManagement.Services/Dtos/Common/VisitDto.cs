namespace Assembly.RealEstateManagement.Services.Dtos.Common;

public class VisitDto
{
    public int Id { get; set; }
    public int ClientId { get;  set; }
    public int PropertyId { get;  set; }
    public int AgentId { get;  set; }
    public DateTime VisitDate { get;  set; }
    public string Notes { get;  set; }
}
