using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IClientRepository : IRepository<Client, int>
{
    public Client Login(string username, string password);

    public List<FavoriteProperties> GetFavoritePropertiesbyClientId(int clientId);

    public List<Client> GetAllClientWithAccount();
    public List<Client> GetAllClientWithAddress();

    public List<Comment> GetCommentsByClientId(int clientId);

    public List<Rating> GetRatingsByClientId(int clientId);

}
