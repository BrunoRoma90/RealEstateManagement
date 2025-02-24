using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.Extensions.Logging;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class CommentRepository : Repository<Comment, int> , ICommentRepository
{
    public CommentRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }



    public List<Comment> GetCommentsByPropertyId(int propertyId)
    {
        return DbSet.Where(c => c.Property.Id == propertyId).ToList();
    }
}
