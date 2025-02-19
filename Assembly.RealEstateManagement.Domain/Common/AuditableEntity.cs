

using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Common;

public class AuditableEntity<TId> : SoftDelete<TId>,
    IAuditableEntity<int>, ISoftDelete, IEntity<TId>
{
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public DateTime Updated { get; set; }
    public int UpdatedBy { get ; set; }
}
