
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class RatingRepository : IRatingRepository
{
    private readonly Database _db;
    public RatingRepository(Database database)
    {
        _db = database;

    }
    public Rating Add(Rating rating)
    {
        _db.Ratings.Add(rating);
        return rating;
    }

    public List<Rating> GetAll()
    {
        var allRatings = new List<Rating>();
        foreach (var rating in _db.Ratings)
        {
            allRatings.Add(rating);
        }
        return allRatings;
    }

    public Rating GetById(int id)
    {
        foreach (var rating in _db.Ratings)
        {
            if (rating.Id == id)
            {
                return rating;

            }
        }
        throw new KeyNotFoundException($"Property with ID {id} was not found."); ;
    }

    public Rating Update(Rating rating)
    {
        var ratings = _db.Ratings.ToList();
        foreach (var existingRating in ratings)
        {
            if (existingRating.Id == rating.Id)
            {
                existingRating.UpdateRating(rating.Value, rating.Property, rating.Client);
                return existingRating;
            }
        }
        throw new KeyNotFoundException($"Rating was not found.");
    }

    public Rating Delete(Rating rating)
    {
        var ratings = _db.Ratings.ToList();
        foreach (var existingRating in ratings)
        {
            if (existingRating.Id == rating.Id)
            {
                _db.Ratings.Remove(existingRating);
            }
        }
        throw new KeyNotFoundException($"Rating was not found.");
    }

    public Rating Delete(int id)
    {
        var ratings = _db.Ratings.ToList();
        foreach (var rating in ratings)
        {
            if (rating.Id == id)
            {
                _db.Ratings.Remove(rating);

            }
        }
        throw new KeyNotFoundException($"Rating with ID {id} was not found.");
    }

 
}
