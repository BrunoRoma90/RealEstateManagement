using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Client;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IFavoritePropertyService
{
    void AddFavoriteProperty(CreateFavoritePropertyDto dto);
    void RemoveFavoriteProperty(RemoveFavoritePropertyDto dto);
    List<FavoritePropertyDto> GetFavoriteProperties(int clientId);
}
