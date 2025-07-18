﻿using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IClientRepository : IRepository<Client, int>
{
    public Client Login(string username, string password);

    public List<FavoriteProperty> GetFavoritePropertiesbyClientId(int clientId);

    public Client? GetClientWithFavorites(int clientId);

    public List<Client> GetAllClientWithAccount();
    public List<Client> GetAllClientWithAddress();

    public List<Comment> GetCommentsByClientId(int clientId);

    public List<Rating> GetRatingsByClientId(int clientId);

    public Account? GetClientAccount(int clientId);

    public Address? GetClientAddress(int clientId);

    public Client? GetByEmail(string email);

}
