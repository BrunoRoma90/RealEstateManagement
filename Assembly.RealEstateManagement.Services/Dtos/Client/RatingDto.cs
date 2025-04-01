using Assembly.RealEstateManagement.Services.Dtos.Property;

namespace Assembly.RealEstateManagement.Services.Dtos.Client;

public class RatingDto
{
    public double Value { get; set; }
    public PropertyDto Property { get;  set; }
}
