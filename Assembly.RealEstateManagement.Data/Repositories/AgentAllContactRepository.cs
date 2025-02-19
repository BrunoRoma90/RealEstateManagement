using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentAllContactRepository : Repository<AgentAllContact, int>, IAgentAllContactRepository
{
    public AgentAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public List<AgentAllContact> GetAgentContacts(int agentId)
    {
        return DbSet.Where(a => a.Agent.Id == agentId).ToList();
    }

}
