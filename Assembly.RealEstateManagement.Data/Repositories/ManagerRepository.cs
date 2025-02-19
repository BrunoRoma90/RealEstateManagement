using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerRepository : Repository<Manager, int>, IManagerRepository
{
    public ManagerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Account? GetManagerAccount(int managerId)
    {
        var manager = DbSet.Include(m => m.Account).FirstOrDefault(m => m.Id == managerId);
        return manager?.Account;
    }

    public Address? GetManagerAddress(int managerId)
    {
        var manager = DbSet.Include(m => m.Address).FirstOrDefault(m => m.Id == managerId);
        return manager?.Address;
    }

    public Manager? GetManagerByEmployeeNumber(int employeeNumber)
    {
        return DbSet.FirstOrDefault(a => a.EmployeeNumber == employeeNumber);
    }

    public Manager? GetManagerByManagerNumber(int managerNumber)
    {
        return DbSet.FirstOrDefault(m => m.ManagerNumber == managerNumber);
    }

    public List<Agent> GetManagerAgents(int managerId)
    {
        var manager = DbSet.Include(m => m.ManagedAgents).FirstOrDefault(m => m.Id == managerId);
        return manager?.ManagedAgents ?? new List<Agent>();
    }

    #region 
    //public void AddAgent(int managerId, Agent agent)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    throw new NotImplementedException();
    //}

    //public void CreateAppointment(int agentId, Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public Agent GetAgent(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Visit> GetAgentCalendar(int agentId)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Agent> GetAgents()
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Agent> GetAgentsByManagerId(int managerId)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Agent> GetAllManagedAgents(int managerId)
    //{
    //    throw new NotImplementedException();
    //}

    //public void RemoveAgent(int managerId, Agent agent)
    //{
    //    throw new NotImplementedException();
    //}

    //public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId)
    //{
    //    throw new NotImplementedException();
    //}

    //public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property)
    //{
    //    throw new NotImplementedException();
    //}
    #endregion


}