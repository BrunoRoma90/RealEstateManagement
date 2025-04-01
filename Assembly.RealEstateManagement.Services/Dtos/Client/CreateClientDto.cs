using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Dtos.Client;

public class CreateClientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public AddressDto Address { get; set; }
    public bool IsRegistered { get; set; }
    public List<FavoritePropertiesDto> FavoriteProperties { get; set; }
    public List<RatingDto> Ratings { get; set; }
    public List<CommentDto> Comments { get; set; }
}
