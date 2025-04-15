using Assembly.RealEstateManagement.Services.Dtos.Client;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IClientServices
{
    IEnumerable<ClientDto> GetClients();

    public ClientDto GetClientById(int id);
    ClientDto Add(CreateClientDto client);

    ClientDto Update(UpdateClient updateClient);
}
