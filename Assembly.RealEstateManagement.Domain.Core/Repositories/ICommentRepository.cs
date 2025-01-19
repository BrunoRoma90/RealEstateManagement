using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface ICommentRepository : IRepository<Comment, int>
{
    
    List<Comment> GetCommentsByClientId(int clientId);

    List<Comment> GetCommentsByPropertyId(int propertyId);
}
