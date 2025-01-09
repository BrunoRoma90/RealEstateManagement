using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class PropertyImage : AuditableEntity<int>
{
    public string ImageUrl { get; private set; }
    public string Description { get; private set; }


    private PropertyImage()
    {
        ImageUrl = string.Empty;
        Description = string.Empty;

    }
    private PropertyImage(string imageUrl, string description)
    {
        ImageUrl = imageUrl;
        Description = description;
        
    }
}
