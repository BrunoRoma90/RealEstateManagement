using System.Linq;
using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentRepository : Repository<Agent, int>, IAgentRepository
{
    public AgentRepository(ApplicationDbContext context) : base(context)
    {

    }

    #region

    //public void AddContactToMyList(int angentId, Contact contact)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddPropertyToMyList(int agentId, Property property)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisitToMyList(int agentId, Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public Property CreateProperty(Property property)
    //{
    //    throw new NotImplementedException();
    //}

    //public void DeleteProperty(int propertyId)
    //{
    //    throw new NotImplementedException();
    //}

    //public void DeleteProperty(Property property)
    //{
    //    throw new NotImplementedException();
    //}
    //public Property GetPropertyById(int propertyId)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Visit> GetVisitsByAgentId(int agentId)
    //{
    //    throw new NotImplementedException();
    //}

    //public void RemoveContactFromMyList(int angentId, Contact contact)
    //{
    //    throw new NotImplementedException();
    //}

    //public void RemovePropertyFromAgent(int agentId, Property property)
    //{
    //    throw new NotImplementedException();
    //}

    //public void RemoveVisitToMyList(int agentId, Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public Property UpdateProperty(Property property)
    //{
    //    throw new NotImplementedException();
    //}



    #endregion

    public Agent? GetAgentByAgentNumber(int agentNumber)
    {
        return DbSet.FirstOrDefault(a => a.AgentNumber == agentNumber);
    }
    public Agent? GetAgentByEmployeeNumber(int employeeNumber)
    {
        return DbSet.FirstOrDefault(a => a.EmployeeNumber == employeeNumber);
    }
    public List<Agent> GetAgentsByManagerId(int managerId)
    {
        return DbSet.Where(a => a.Manager.Id == managerId).ToList();
    }

    public Manager? GetManagerByAgentId(int agentId)
    {
        return DbSet.Where(a => a.Id == agentId)
                    .Select(a => a.Manager)
                    .FirstOrDefault();
    }

    public Account? GetAgentAccount(int agentId)
    {
        var agent = DbSet.Include(a => a.Account).FirstOrDefault(a => a.Id == agentId);
        return agent?.Account;
    }

    public Address? GetAgentAddress(int agentId)
    {
        var agent = DbSet.Include(a => a.Address).FirstOrDefault(a => a.Id == agentId);
        return agent?.Address;
    }



}
