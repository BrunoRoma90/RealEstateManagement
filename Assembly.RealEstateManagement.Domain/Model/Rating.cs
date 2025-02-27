using Assembly.RealEstateManagement.Domain.Common;
using static System.Net.Mime.MediaTypeNames;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    private Rating() { }

    private Rating(int id,double value, Property property):this()
    {
        ValidateRating(value , property);
        Value = value;
        Property = property;

    }

    private Rating(double value, Property property) : this()
    {
        ValidateRating(value, property);
        Value = value;
        Property = property;

    }

    public static Rating Create(double value, Property property)
    {
        return new Rating(value, property);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(Rating rating)
    {
        rating.IsDeleted = false;
    }

    public static Rating Update(double newValue, Property newProperty)
    {
        return new Rating(newValue, newProperty);
    }

    private void ValidateRating(double value, Property property)
    {
        if (value <= 0)
        {
            throw new ArgumentException(nameof(value), "Value must be greater than zero.");
        }
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }

    }


}


