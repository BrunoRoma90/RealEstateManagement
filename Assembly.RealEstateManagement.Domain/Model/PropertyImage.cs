
using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class PropertyImage : AuditableEntity<int>
{
    public string ImageUrl { get; private set; }
    public string Description { get; private set; }

    private PropertyImage() { }

    private PropertyImage(string imageUrl, string description):this()
    {
        ImageUrl = imageUrl;
        Description = description;
    }
}
