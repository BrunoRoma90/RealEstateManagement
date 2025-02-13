using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    private Rating() { }

    private Rating(double value, Property property):this()
    {
        ValidateRating(value , property);
        Value = value;
        Property = property;
        Created = DateTime.Now;
        Updated = DateTime.Now;
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


