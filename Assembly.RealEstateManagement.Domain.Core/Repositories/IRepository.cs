using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IRepository<TEntity, TId> where TEntity : IEntity<TId>
{
    List<TEntity> GetAll();

    TEntity GetById(TId id);

    TEntity Add(TEntity obj);

    TEntity Update(TEntity obj);

    TEntity Delete(TEntity obj);

    TEntity Delete(TId id);
}
