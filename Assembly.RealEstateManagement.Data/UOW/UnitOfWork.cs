using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Assembly.RealEstateManagement.Data.UOW;

internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDbContextTransaction _dbContextTransaction;

    public IManagerRepository ManagerRepository { get; set; }

    public UnitOfWork(ApplicationDbContext context, IManagerRepository managerRepository) 
    {
        _context = context;
        ManagerRepository = managerRepository;
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
