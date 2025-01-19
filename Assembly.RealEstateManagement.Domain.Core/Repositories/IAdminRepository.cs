﻿using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdminRepository : IRepository<Admin, int>
{
    public List<Agent> GetAgents();
    public List<Manager> GetManagers();
    public List<AdministrativeUsers> GetAdministrativeUsers();

    public List<Client> GetClients();

    public Agent GetAgent(int id);

    public Manager GetManager(int id);

    public AdministrativeUsers GetAdministrativeUser(int id);

    public Client GetClient(int id);

    

}
