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

    public AgentAllContact? GetAgentContactWithAgent(int id)
    {
        return DbSet.Include(x => x.Agent)
            .ThenInclude(m => m.Account)
            .Include(m => m.Agent.Address)
            .FirstOrDefault(x => x.Id == id);
    }


    public List<AgentAllContact> GetAgentContacts(int agentId)
    {
        return DbSet.Where(a => a.Agent.Id == agentId).ToList();
    }

    public List<AgentAllContact> GetAllAgentAllContactWithAgent()
    {
        return DbSet.Include(x => x.Agent)
            .ThenInclude(m => m.Account)
            .Include(m => m.Agent.Address)
            .ToList();
    }

}
