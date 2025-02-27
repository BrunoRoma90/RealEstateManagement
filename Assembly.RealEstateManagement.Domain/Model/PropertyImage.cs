
using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class PropertyImage : AuditableEntity<int>
{
    public string ImageUrl { get; private set; }
    public string Description { get; private set; }

    private PropertyImage() { }

    private PropertyImage(int id ,string imageUrl, string description) :this()
    {
        ValidatePropertyImage(imageUrl, description);
        ImageUrl = imageUrl;
        Description = description;

    }

    private PropertyImage(string imageUrl, string description) : this()
    {
        ValidatePropertyImage(imageUrl, description);
        ImageUrl = imageUrl;
        Description = description;
      
    }

    public static PropertyImage Create(string imageUrl, string description)
    {
        return new PropertyImage(imageUrl, description);
    }

    public static PropertyImage Update(string newImageUrl, string newDescription)
    {
        return new PropertyImage(newImageUrl, newDescription);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(PropertyImage propertyImage)
    {
        propertyImage.IsDeleted = false;
    }

    private void ValidatePropertyImage(string imageUrl, string description)
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            throw new ArgumentNullException("ImageUrl is required");
        }
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException("Description is required");
        }
    }
}
