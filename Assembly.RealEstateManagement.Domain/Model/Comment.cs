using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }

    private Comment() { }

    private Comment(string text, Property property):this()
    {
        Text = text;
        Property = property;
    }
}


