using Assembly.RealEstateManagement.Domain.Common;


namespace Assembly.RealEstateManagement.Domain.Model;

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    private Rating() { }

    private Rating(double value, Property property):this()
    {
        Value = value;
        Property = property;
    }


}


