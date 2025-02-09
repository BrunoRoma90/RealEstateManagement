using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    private readonly ApplicationDbContext _dbContext;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
        DbSet = _dbContext.Set<TEntity>();
    }

    public List<TEntity> GetAll()
    {
        return DbSet.ToList();
    }

    public TEntity? GetById(TId id)
    {
        return DbSet.Find(id);
    }
    public TEntity Add(TEntity obj)
    {
        var entity = DbSet.Add(obj).Entity;
        _dbContext.SaveChanges();
        return obj;
    }
    public TEntity Update(TEntity obj)
    {
        DbSet.Update(obj);
        _dbContext.SaveChanges();
        return obj;
    }
    public TEntity Delete(TEntity obj)
    {
        DbSet.Remove(obj);
        _dbContext.SaveChanges();
        return obj;
    }

    public TEntity? Delete(TId id)
    {
        var obj = GetById(id);

        if (obj != null) 
        {
            Delete(obj);
            _dbContext.SaveChanges();
            return obj;
        }
        return null;
    }

    

    

    
}
