using Assembly.RealEstateManagement.Domain.Core.Repositories;

namespace Assembly.RealEstateManagement.Domain.Core;

public interface IUnitOfWork : IDisposable
{
    public IManagerRepository ManagerRepository { get; }
    public IAgentRepository AgentRepository { get; }

    public IAdministrativeUsersRepository AdministrativeUsersRepository { get; }

    public IManagerPersonalContactRepository ManagerPersonalContactRepository { get; }
    public IAgentPersonalContactRepository AgentPersonalContactRepository { get; }
    public IAdministrativeUserPersonalContactRepository AdministrativeUserPersonalContactRepository { get; }

    public IManagerAllContactRepository ManagerAllContactRepository { get; }
    public IAgentAllContactRepository AgentAllContactRepository { get; }
    public IAdministrativeUserAllContactRepository AdministrativeUserAllContactRepository { get; }

    public IPropertyRepository PropertyRepository { get; }

    public IClientRepository ClientRepository { get; }

    public IVisitRepository VisitRepository { get; }

    void BeginTransaction();
    public bool Commit();
}
