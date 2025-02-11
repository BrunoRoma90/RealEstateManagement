using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentAllContactRepository : Repository<AgentAllContact, int>, IAgentAllContactRepository
{
    public AgentAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }
}
