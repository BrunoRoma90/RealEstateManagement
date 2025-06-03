using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Client;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class ClientServices : IClientServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public IEnumerable<ClientDto> GetClients()
    {
        var clients = new List<Client>();

        clients = _unitOfWork.ClientRepository.GetAllClientWithAccount();
        clients = _unitOfWork.ClientRepository.GetAllClientWithAddress();



        return clients.Select(x => new ClientDto
        {

            FirstName = x.Name.FirstName,
            LastName = x.Name.LastName,
            Email = x.Account.Email,
            Address = new AddressDto
            {
                Street = x.Address.Street,
                Number = x.Address.Number,
                PostalCode = x.Address.PostalCode,
                City = x.Address.City,
                Country = x.Address.Country,
            },
            IsRegistered = x.IsRegistered,
            FavoriteProperties = _unitOfWork.ClientRepository.GetFavoritePropertiesbyClientId(x.Id)
            .Select(fP => new FavoritePropertiesDto
            {
                ClientId = x.Id,
                Property = new PropertyDto
                {
                    Id = fP.Id,
                    Address = new AddressDto
                    {
                        Street = fP.Property.Address.Street,
                        Number = fP.Property.Address.Number,
                        PostalCode = fP.Property.Address.PostalCode,
                        City = fP.Property.Address.City,
                        Country = fP.Property.Address.Country
                    },
                    PropertyType = fP.Property.PropertyType,
                    Price = fP.Property.Price,
                    PriceBySquareMeter = fP.Property.PriceBySquareMeter,
                    SizeBySquareMeters = fP.Property.SizeBySquareMeters,
                    Description = fP.Property.Description,
                    TransactionType = fP.Property.TransactionType,
                    Availability = fP.Property.Availability,
                }

            }).ToList(),




        }).ToList();
    }


    public ClientDto GetClientById(int id)
    {
        var client = _unitOfWork.ClientRepository.GetById(id);
        var account = _unitOfWork.ClientRepository.GetClientAccount(id);
        var address = _unitOfWork.ClientRepository.GetClientAddress(id);

        

        if (client is null)
        {
            throw new ArgumentNullException(nameof(client), "property id not found");
        }
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "account id not found");
        }
        if (address is null)
        {
            throw new ArgumentNullException(nameof(address), "address id not found");
        }

        return new ClientDto
        {
            Id = client.Id,
            FirstName = client.Name.FirstName,
            LastName = client.Name.LastName,
            Email = client.Account.Email,
            Address = new AddressDto
            {
                Street = address.Street,
                Number = address.Number,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country,
            },
            IsRegistered = client.IsRegistered,
            FavoriteProperties = _unitOfWork.ClientRepository.GetFavoritePropertiesbyClientId(client.Id)
            .Select(fP => new FavoritePropertiesDto
            {
                ClientId = client.Id,
                Property = new PropertyDto
                {
                    Id = fP.Id,
                    Address = new AddressDto
                    {
                        Street = fP.Property.Address.Street,
                        Number = fP.Property.Address.Number,
                        PostalCode = fP.Property.Address.PostalCode,
                        City = fP.Property.Address.City,
                        Country = fP.Property.Address.Country
                    },
                    PropertyType = fP.Property.PropertyType,
                    Price = fP.Property.Price,
                    PriceBySquareMeter = fP.Property.PriceBySquareMeter,
                    SizeBySquareMeters = fP.Property.SizeBySquareMeters,
                    Description = fP.Property.Description,
                    TransactionType = fP.Property.TransactionType,
                    Availability = fP.Property.Availability,
                }

            }).ToList(),


        };
    }

    public ClientDto Add(CreateClientDto client)
    {
        Client addedClient;

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();

            Client clientToAdd = Client.Create(
            Name.Create(client.FirstName, client.MiddleNames, client.LastName),
            client.Email,
            client.Password,
            Address.Create(client.Address.Street, client.Address.Number, client.Address.PostalCode, client.Address.City, client.Address.Country),
            new List<FavoriteProperty>(),
            new List<Rating>(),
            new List<Comment>());

            addedClient = _unitOfWork.ClientRepository.Add(clientToAdd);
            _unitOfWork.Commit();
        }

        var clientDto = new ClientDto
        {
            Id = addedClient.Id,
            FirstName = addedClient.Name.FirstName,
            LastName = addedClient.Name.LastName,
            Email = addedClient.Account.Email,
            Address = new AddressDto
            {
                Street = addedClient.Address.Street,
                Number = addedClient.Address.Number,
                PostalCode = addedClient.Address.PostalCode,
                City = addedClient.Address.City,
                Country = addedClient.Address.Country,

            },
           IsRegistered = addedClient.IsRegistered,
        };


        return clientDto;
    }

    public ClientDto Update(UpdateClient client)
    {
        var existingClient = _unitOfWork.ClientRepository.GetById(client.Id);
        var existingAddress = _unitOfWork.ClientRepository.GetClientAddress(client.Id);
        var existingAccount = _unitOfWork.ClientRepository.GetClientAccount(client.Id);

        if (existingClient is null)
            throw new KeyNotFoundException("Manager not found.");

        if (existingAccount is null)
            throw new KeyNotFoundException("Manager account not found.");

        if (existingAddress is null)
            throw new KeyNotFoundException("Manager address not found.");

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();


            string IsValidString(string? value, string current) =>
            string.IsNullOrWhiteSpace(value) || value == "string" ? current : value;

            string[] IsValidArray(string[]? value, string[] current) =>
                value == null || value.Length == 0 || (value.Length == 1 && value[0] == "string") ? current : value;

            existingClient.Name.Update(
                IsValidString(client.FirstName, existingClient.Name.FirstName),
                IsValidArray(client.MiddleNames, existingClient.Name.MiddleNames),
                IsValidString(client.LastName, existingClient.Name.LastName));

            existingClient.Account.Update(
                IsValidString(client.Email, existingClient.Account.Email),
                client.Password ?? string.Empty);

            existingClient.Address.UpdateAddress(
                IsValidString(client.Address?.Street, existingClient.Address.Street),
                client.Address?.Number == 0 ? existingClient.Address.Number : client.Address.Number,
                IsValidString(client.Address?.PostalCode, existingClient.Address.PostalCode),
                IsValidString(client.Address?.City, existingClient.Address.City),
                IsValidString(client.Address?.Country, existingClient.Address.Country)
            );


            existingClient.Update(
                existingClient.Id,
                existingClient.Name,
                IsValidString(client.Email, existingClient.Account.Email),
                client.Password ?? string.Empty,
                existingClient.Address,
                new List<FavoriteProperty>(),
                new List<Rating>(),
                new List<Comment>()
            );


            _unitOfWork.ClientRepository.Update(existingClient);
            _unitOfWork.Commit();


            var clientDto = new ClientDto
            {
                Id = existingClient.Id,
                FirstName = existingClient.Name.FirstName,
                LastName = existingClient.Name.LastName,
                Email = existingClient.Account.Email,
                Address = new AddressDto
                {
                    Street = existingClient.Address.Street,
                    Number = existingClient.Address.Number,
                    PostalCode = existingClient.Address.PostalCode,
                    City = existingClient.Address.City,
                    Country = existingClient.Address.Country
                }
            };

            return clientDto;
        }
    }
}
