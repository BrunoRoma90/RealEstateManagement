using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Client;
using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

internal class FavoritePropertyService : IFavoritePropertyService
{
    private readonly IUnitOfWork _unitOfWork;

    public FavoritePropertyService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddFavoriteProperty(CreateFavoritePropertyDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        if (_unitOfWork.FavoritePropertyRepository.Exists(dto.ClientId, dto.PropertyId))
            throw new InvalidOperationException("Property is already in favorites.");

        var property = _unitOfWork.PropertyRepository.GetById(dto.PropertyId)
                      ?? throw new ArgumentException("Property not found.");

        var client = _unitOfWork.ClientRepository.GetById(dto.ClientId)
                     ?? throw new ArgumentException("Client not found.");

        var favorite = FavoriteProperty.Create(dto.ClientId, dto.PropertyId);

        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.FavoritePropertyRepository.Add(favorite);
            _unitOfWork.Commit();
        }
    }

    public void RemoveFavoriteProperty(RemoveFavoritePropertyDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        
        var client = _unitOfWork.ClientRepository.GetById(dto.ClientId);
        if (client == null)
            throw new ArgumentException("Client not found.");

        
        var property = _unitOfWork.PropertyRepository.GetById(dto.PropertyId);
        if (property == null)
            throw new ArgumentException("Property not found.");

        
        var favorite = _unitOfWork.FavoritePropertyRepository
            .GetByClientAndPropertyId(dto.ClientId, dto.PropertyId);

        if (favorite == null)
            throw new InvalidOperationException("Favorite property not found.");

        
        using (_unitOfWork)
        {
            _unitOfWork.BeginTransaction();
            _unitOfWork.FavoritePropertyRepository.Delete(favorite);
            _unitOfWork.Commit();
        }
    }

    public List<FavoritePropertyDto> GetFavoriteProperties(int clientId)
    {
        var favorites = _unitOfWork.FavoritePropertyRepository.GetByClientId(clientId);

        return favorites.Select(f => new FavoritePropertyDto
        {
            ClientId = f.ClientId,
            Property = new PropertyDto
            {
                Id = f.Property.Id,
                Address = new AddressDto
                {
                    Street = f.Property.Address.Street,
                    Number = f.Property.Address.Number,
                    PostalCode = f.Property.Address.PostalCode,
                    City = f.Property.Address.City,
                    Country = f.Property.Address.Country
                },
                PropertyType = f.Property.PropertyType,
                Price = f.Property.Price,
                PriceBySquareMeter = f.Property.PriceBySquareMeter,
                SizeBySquareMeters = f.Property.SizeBySquareMeters,
                Description = f.Property.Description,
                TransactionType = f.Property.TransactionType,
                Availability = f.Property.Availability
            }
        }).ToList();
    }

    
}


