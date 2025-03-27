using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Data.Repositories;
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assembly.RealEstateManagement.Data.UOW;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _dbContextTransaction;

    public IManagerRepository ManagerRepository { get; set; }
    public IAgentRepository AgentRepository { get; set; }

    public IAdministrativeUsersRepository AdministrativeUsersRepository { get; set; }

    public IManagerPersonalContactRepository ManagerPersonalContactRepository { get; set; }
    public IAgentPersonalContactRepository AgentPersonalContactRepository { get; set; }
    public IAdministrativeUserPersonalContactRepository AdministrativeUserPersonalContactRepository { get; set; }

    public IManagerAllContactRepository ManagerAllContactRepository { get; set; }
    public IAgentAllContactRepository AgentAllContactRepository { get; set; }
    public IAdministrativeUserAllContactRepository AdministrativeUserAllContactRepository { get; set; }



    public UnitOfWork(ApplicationDbContext context, IManagerRepository managerRepository,
        IAgentRepository agentRepository,
        IAdministrativeUsersRepository administrativeUsersRepository,
        IManagerPersonalContactRepository managerPersonalContactRepository,
        IAgentPersonalContactRepository agentPersonalContactRepository,
        IAdministrativeUserPersonalContactRepository administrativeUserPersonalContactRepository,
        IManagerAllContactRepository managerAllContactRepository,
        IAgentAllContactRepository agentAllContactRepository,
        IAdministrativeUserAllContactRepository administrativeUserAllContactRepository) 
    {
        _context = context;
        ManagerRepository = managerRepository;
        AgentRepository = agentRepository;
        AdministrativeUsersRepository = administrativeUsersRepository;
        ManagerPersonalContactRepository = managerPersonalContactRepository;
        AgentPersonalContactRepository = agentPersonalContactRepository;
        AdministrativeUserPersonalContactRepository = administrativeUserPersonalContactRepository;
        ManagerAllContactRepository = managerAllContactRepository;
        AgentAllContactRepository = agentAllContactRepository;
        AdministrativeUserAllContactRepository = administrativeUserAllContactRepository;
    }

    public void BeginTransaction()
    {
        _dbContextTransaction = _context.Database.BeginTransaction();
    }

    public bool Commit() 
    {
        bool commited = false;

        try
        {
            var affectedRows = _context.SaveChanges();
            _dbContextTransaction.Commit();
            return affectedRows != 0;
        }
        catch 
        {
            _dbContextTransaction.Rollback();
        }
        finally 
        {
            Dispose();
        }
        return commited;
    }


    public void Dispose() 
    {
        _context.Dispose();
    }

}
