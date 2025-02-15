﻿using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IClientRepository : IRepository<Client, int>
{
    public Client Login(string username, string password);

}
