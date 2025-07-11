﻿using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ClientRepository : Repository<Client, int>, IClientRepository
{
    public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    //public List<FavoriteProperty> GetFavoritePropertiesbyClientId(int clientId)
    //{
    //    return DbSet.Where(c => c.Id == clientId)
    //            .SelectMany(c => c.FavoriteProperties)
    //            .ToList();
    //}

  
    public List<FavoriteProperty> GetFavoritePropertiesbyClientId(int clientId)
    {
        return DbSet
            .Include(c => c.FavoriteProperties)
                .ThenInclude(fp => fp.Property)
            .Where(c => c.Id == clientId)
            .SelectMany(c => c.FavoriteProperties)
            .ToList();
    }

    public Client? GetClientWithFavorites(int clientId)
    {
        return DbSet
            .Include(c => c.FavoriteProperties)
                .ThenInclude(fp => fp.Property)
            .FirstOrDefault(c => c.Id == clientId);
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


    public List<Client> GetAllClientWithAccount()
    {
        return DbSet.Include(x => x.Account).ToList();
    }

    public List<Client> GetAllClientWithAddress()
    {
        return DbSet.Include(x => x.Address).ToList();
    }

    public Account? GetClientAccount(int clientId)
    {
        var client = DbSet.Include(a => a.Account).FirstOrDefault(a => a.Id == clientId);
        return client?.Account;
    }

    public Address? GetClientAddress(int clientId)
    {
        var client = DbSet.Include(a => a.Address).FirstOrDefault(a => a.Id == clientId);
        return client?.Address;
    }

    public Client? GetByEmail(string email)
    {
        return DbSet
            .Include(a => a.Account)
            .FirstOrDefault(a => a.Account.Email == email);
    }

   
}
