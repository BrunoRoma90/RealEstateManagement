
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

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
        VadidatePropertyImage(imageUrl, description);
        ImageUrl = imageUrl;
        Description = description;
        
    }

    public static PropertyImage Create(string imageUrl, string description)
    {
        return new PropertyImage(imageUrl, description);
    }

    public void Update(PropertyImage newPropertyImage)
    {
        VadidatePropertyImage(newPropertyImage.ImageUrl, newPropertyImage.Description);
        ImageUrl = newPropertyImage.ImageUrl;
        Description = newPropertyImage.Description;

    }

    private void VadidatePropertyImage(string imageUrl, string description)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new ArgumentNullException(nameof(imageUrl), "Image Url is required");
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(nameof(description), "Description is required");
        }

    }
}
