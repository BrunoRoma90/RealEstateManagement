using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentPersonalContactRepository : Repository<AgentPersonalContact, int>, IAgentPersonalContactRepository
{
    public AgentPersonalContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public List<AgentPersonalContact> GetMyPersonalContacts(int agentId)
    {
        return DbSet.Where(apc => apc.Agent.Id == agentId).ToList();
    }


    public List<AgentPersonalContact> GetAllAgentPersonalContactWithAgent()
    {
        return DbSet.Include(x => x.Agent)
            .ThenInclude(m => m.Account)
            .Include(m => m.Agent.Address)
            .ToList();
    }

}
