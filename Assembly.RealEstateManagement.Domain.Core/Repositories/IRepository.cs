using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;

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

public interface IPersonRepository : IRepository<Person, int>
{
    
}

public interface IAddressRepository : IRepository<Address, int>
{

}

public interface IContactRepository : IRepository<Contact, int>
{

}