using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentPersonalContactRepository : Repository<AgentPersonalContact, int>, IAgentPersonalContactRepository
{
    public AgentPersonalContactRepository(ApplicationDbContext context) : base(context)
    {

    }

}
