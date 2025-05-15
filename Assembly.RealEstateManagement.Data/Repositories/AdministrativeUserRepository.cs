using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AdministrativeUserRepository : Repository<AdministrativeUser, int>, IAdministrativeUsersRepository
{
    public AdministrativeUserRepository(ApplicationDbContext context) : base(context)
    {

    }

    public AdministrativeUser? GetAdministrativeUserByAdministrativeUserNumber(int administrativeUserNumber)
    {
        return DbSet.FirstOrDefault(au => au.AdministrativeNumber == administrativeUserNumber);
    }

    public Account? GetAdministrativeUserAccount(int administrativeUserId)
    {
        var administrativeUser = DbSet.Include(au => au.Account).FirstOrDefault(au => au.Id == administrativeUserId);
        return administrativeUser?.Account;
    }

    public Address? GetAdministrativeUserAddress(int administrativeUserId)
    {
        var administrativeUser = DbSet.Include(au => au.Address).FirstOrDefault(au => au.Id == administrativeUserId);
        return administrativeUser?.Address;
    }

    public AdministrativeUser? GetAdministrativeUserByEmployeeNumber(int employeeNumber)
    {
        return DbSet.FirstOrDefault(au => au.EmployeeNumber == employeeNumber);
    }

    public List<AdministrativeUser> GetAllAdministrativeUserWithAccount()
    {
        return DbSet.Include(x => x.Account).ToList();
    }

    public List<AdministrativeUser> GetAllAdministrativeUserWithAddress()
    {
        return DbSet.Include(x => x.Address).ToList();
    }

    public AdministrativeUser? GetByEmail(string email)
    {
        return DbSet
            .Include(a => a.Account)
            .FirstOrDefault(a => a.Account.Email == email);
    }


    #region
    //public AdministrativeUser Add(AdministrativeUser obj)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddNotes(int visitId, string notes)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisit(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisitToAgent(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisitToClient(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public Client CreateClient(Client client)
    //{
    //    throw new NotImplementedException();
    //}

    //public AdministrativeUser Delete(AdministrativeUser obj)
    //{
    //    throw new NotImplementedException();
    //}

    //public Agent GetAgent(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Agent> GetAgents()
    //{
    //    throw new NotImplementedException();
    //}

    //public Client GetClient(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Client> GetClients()
    //{
    //    throw new NotImplementedException();
    //}

    //public Manager GetManager(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Manager> GetManagers()
    //{
    //    throw new NotImplementedException();
    //}

    //public Visit GetVisitByAgentId(int agentId)
    //{
    //    throw new NotImplementedException();
    //}

    //public Visit GetVisitByClientId(int clientId)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Visit> GetVisits()
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Visit> GetVisitsByAgentId(int agentId)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<Visit> GetVisitsByClientId(int clientId)
    //{
    //    throw new NotImplementedException();
    //}

    //public AdministrativeUser Update(AdministrativeUser obj)
    //{
    //    throw new NotImplementedException();
    //}

    //public Visit UpdateVisit(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //AdministrativeUser? IRepository<AdministrativeUser, int>.Delete(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //List<AdministrativeUser> IRepository<AdministrativeUser, int>.GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //AdministrativeUser? IRepository<AdministrativeUser, int>.GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    #endregion
}
