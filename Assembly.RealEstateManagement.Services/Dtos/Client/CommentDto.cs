using Assembly.RealEstateManagement.Services.Dtos.Property;

namespace Assembly.RealEstateManagement.Services.Dtos.Client;

public class CommentDto
{
    public string Text { get; private set; }
    public PropertyDto Property { get; private set; }
}
