using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }
    public Client Client { get; private set; }

    private Comment()
    {
        Text = string.Empty;
        Property = null;
        Client = null;
    }
    private Comment(string text, Property property, Client client)
    {
        Text = text;
        Property = property;
        Client = client;
    }
}


