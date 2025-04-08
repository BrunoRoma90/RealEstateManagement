using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IVisitServices
{
    IEnumerable<VisitDto> GetVisits();

    public VisitDto GetVisitById(int id);
    VisitDto Add(CreateVisitDto visit);
}
