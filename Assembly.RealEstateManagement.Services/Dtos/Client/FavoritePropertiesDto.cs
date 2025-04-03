using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Property;

namespace Assembly.RealEstateManagement.Services.Dtos.Client;

public class FavoritePropertiesDto
{
    public int ClientId {  get; set; }
    public PropertyDto Property{ get; set; }
}
