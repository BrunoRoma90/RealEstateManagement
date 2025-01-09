namespace Assembly.RealEstateManagement.Domain.Common;

public class Entity<TId> : IEntity<TId>
{
    public TId Id { get; protected set; }


}
