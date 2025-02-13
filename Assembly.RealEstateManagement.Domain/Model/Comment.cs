using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }

    private Comment() { }

    private Comment(string text, Property property):this()
    {
        ValidateComment(text, property);
        Text = text;
        Property = property;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private void ValidateComment(string text, Property property)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException("Text is required.");
        }
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }

    }
}


