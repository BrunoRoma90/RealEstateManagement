
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class FavoritePropertiesRepository : IFavoriteProperties
{
    private readonly Database _db;
    public FavoritePropertiesRepository(Database database)
    {
        _db = database;
    }

    public FavoriteProperties Add(FavoriteProperties favoriteProperty)
    {
        _db.FavoriteProperties.Add(favoriteProperty);
        return favoriteProperty;
    }

    public List<FavoriteProperties> GetAll()
    {

        var AllFavoriteProperties = new List<FavoriteProperties>();
        foreach (var favoriteProperty in _db.FavoriteProperties)
        {
            AllFavoriteProperties.Add(favoriteProperty);
        }
        return AllFavoriteProperties;
    }

    public FavoriteProperties GetById(int id)
    {
        foreach (var favoriteProperty in _db.FavoriteProperties)
        {
            if (favoriteProperty.Id == id)
            {
                return favoriteProperty;

            }
        }
        throw new KeyNotFoundException($"Favorite Property with ID {id} was not found."); ;
    }

    public FavoriteProperties Update(FavoriteProperties favoriteProperty)
    {
        var favoriteProperties = _db.FavoriteProperties.ToList();
        foreach (var existingFavoriteProperty in favoriteProperties)
        {
            if (existingFavoriteProperty.Id == favoriteProperty.Id)
            {
                existingFavoriteProperty.UpdateFavoriteProperties(favoriteProperty.Client, favoriteProperty.Property);
                return existingFavoriteProperty;
            }
        }
        throw new KeyNotFoundException($"Rating was not found.");
    }

    public FavoriteProperties Delete(FavoriteProperties favoriteProperty)
    {
        var favoriteProperties = _db.FavoriteProperties.ToList();
        foreach (var existingfavoriteProperty in favoriteProperties)
        {
            if (existingfavoriteProperty.Id == favoriteProperty.Id)
            {
                _db.FavoriteProperties.Remove(existingfavoriteProperty);
            }
        }
        throw new KeyNotFoundException($"Favorite Property was not found.");
    }

    public FavoriteProperties Delete(int id)
    {
        var favoriteProperties = _db.FavoriteProperties.ToList();
        foreach (var favoriteProperty in favoriteProperties)
        {
            if (favoriteProperty.Id == id)
            {
                _db.FavoriteProperties.Remove(favoriteProperty);

            }
        }
        throw new KeyNotFoundException($"Favorite Property with ID {id} was not found.");
    }
}
