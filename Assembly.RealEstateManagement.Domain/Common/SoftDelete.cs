

using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Common;

public class SoftDelete<TId> : Entity<TId> , ISoftDelete
{
    public bool IsDeleted { get; protected set; }
}
