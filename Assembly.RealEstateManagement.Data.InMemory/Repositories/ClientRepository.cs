using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class ClientRepository : IClientRepository
{
    private readonly Database _db;

    public ClientRepository(Database database)
    {
        _db = database;

    }

    public Client Add(Client client)
    {
        _db.Clients.Add(client);
        return client;
    }

    public List<Client> GetAll()
    {
        var allClients = new List<Client>();
        foreach (var client in _db.Clients)
        {
            allClients.Add(client);
        }
        return allClients;
    }

    public Client GetById(int id)
    {
        foreach (var client in _db.Clients)
        {
            if (client.Id == id)
            {
                return client;

            }
        }
        throw new KeyNotFoundException($"Client with ID {id} was not found.");
    }

    public Client Delete(Client client)
    {
        var clients = _db.Clients.ToList();
        foreach (var existingClient in clients)
        {
            if (existingClient.Id == client.Id)
            {
                _db.Clients.Remove(existingClient);
            }
        }
        throw new KeyNotFoundException($"Client was not found.");
    }

    public Client Delete(int id)
    {
        var clients = _db.Clients.ToList();
        foreach (var client in clients)
        {
            if (client.Id == id)
            {
                _db.Clients.Remove(client);

            }
        }
        throw new KeyNotFoundException($"Client with ID {id} was not found.");
    }


    public Client Update(Client client)
    {
        var clients = _db.Clients.ToList();
        foreach (var existingClient in clients)
        {
            if (existingClient.Id == client.Id)
            {
                existingClient.UpdateClient(client.Name, client.Account, client.Contact, client.IsRegistered, client.FavoriteProperties,
                    client.Ratings, client.Comments, client.Visits);
                return existingClient;
            }
        }
        throw new KeyNotFoundException($"Client was not found.");
    }
}
