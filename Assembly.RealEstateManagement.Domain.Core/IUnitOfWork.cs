using Assembly.RealEstateManagement.Domain.Core.Repositories;

namespace Assembly.RealEstateManagement.Domain.Core;

public interface IUnitOfWork : IDisposable
{
    public IManagerRepository ManagerRepository { get; }

    void BeginTransaction();
    public bool Commit();
}
