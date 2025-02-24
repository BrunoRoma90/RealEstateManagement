using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ClientRepository : Repository<Client, int>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public List<FavoriteProperties> GetFavoritePropertiesbyClientId(int clientId)
    {
        return DbSet.Where(c => c.Id == clientId)
                .SelectMany(c => c.FavoriteProperties)
                .ToList();
    }

    public List<Comment> GetCommentsByClientId(int clientId)
    {
        return DbSet.Where(c => c.Id == clientId)
               .SelectMany(c => c.Comments)
               .ToList();
    }

    public List<Rating> GetRatingsByClientId(int clientId)
    {
        return DbSet.Where(c => c.Id == clientId)
               .SelectMany(c => c.Ratings)
               .ToList();
    }


    public Client Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    
}
