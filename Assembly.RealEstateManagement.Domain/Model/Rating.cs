using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Rating : AuditableEntity<int>
{
    public double Value { get; private set; }
    public Property Property { get; private set; }

    public Client Client { get; private set; }

    private Rating()
    {
        Value = 0;
        Property = null;
        Client = null;
    }
    private Rating(double value, Property property, Client client)
    {
        Value = value;
        Property = property;
        Client = client;
    }
}


