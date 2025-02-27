

namespace Assembly.RealEstateManagement.Domain.Interfaces;

public interface IAuditableEntity<TUserId> 
{
    public DateTime Created { get; }

    public TUserId CreatedBy { get;}

    public DateTime Updated { get; }

    public TUserId UpdatedBy { get; }

    void Create(DateTime created);

    void Update(DateTime updated);
}
