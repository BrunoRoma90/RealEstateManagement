using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories
{
    internal class FavoritePropertyRepository : Repository<FavoriteProperty, int>, IFavoritePropertyRepository
    {
        public FavoritePropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public bool Exists(int clientId, int propertyId)
        {
            return DbSet.Any(f => f.ClientId == clientId && f.PropertyId == propertyId);
        }

        public List<FavoriteProperty> GetByClientId(int clientId)
        {
            return DbSet.Where(f => f.ClientId == clientId)
                        .ToList();
        }

        public FavoriteProperty? GetByClientAndPropertyId(int clientId, int propertyId)
        {
            return DbSet.FirstOrDefault(f => f.ClientId == clientId && f.PropertyId == propertyId);
        }
    }
}
