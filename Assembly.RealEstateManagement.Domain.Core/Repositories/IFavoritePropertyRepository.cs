using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories
{
    public interface IFavoritePropertyRepository : IRepository<FavoriteProperty, int>
    {
        bool Exists(int clientId, int propertyId);
        List<FavoriteProperty> GetByClientId(int clientId);
    }
}
