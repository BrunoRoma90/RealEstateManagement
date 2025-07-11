﻿using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdministrativeUsersRepository : IRepository<AdministrativeUser , int> 
{

    public Account? GetAdministrativeUserAccount(int administrativeUserId);
    public Address? GetAdministrativeUserAddress(int administrativeUserId);
    public AdministrativeUser? GetAdministrativeUserByAdministrativeUserNumber(int administrativeUserNumber);

    public AdministrativeUser? GetAdministrativeUserByEmployeeNumber(int employeeNumber);

    public List<AdministrativeUser> GetAllAdministrativeUserWithAccount();

    public List<AdministrativeUser> GetAllAdministrativeUserWithAddress();

    public AdministrativeUser? GetByEmail(string email);


    #region
    //public List<Agent> GetAgents();
    //public List<Manager> GetManagers();

    //public List<Visit> GetVisits();

    //public List<Client> GetClients();

    //public Agent GetAgent(int id);

    //public Manager GetManager(int id);

    //public Client GetClient(int id);

    //public List<Visit> GetVisitsByClientId(int clientId);

    //public List<Visit> GetVisitsByAgentId(int agentId);

    //public Visit GetVisitByClientId(int clientId);

    //public Visit GetVisitByAgentId(int agentId);
    //public Visit UpdateVisit(Visit visit);

    //public void AddVisit(Visit visit);

    //public void AddVisitToAgent(Visit visit);
    //public void AddVisitToClient(Visit visit);

    //public void AddNotes(int visitId, string notes);

    //public Client CreateClient(Client client);
    #endregion

}
