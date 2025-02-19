using System.Runtime.InteropServices;
using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Comment : AuditableEntity<int>
{
    public string Text { get; private set; }
    public Property Property { get; private set; }

    private Comment() { }

    private Comment(int id,string text, Property property):this()
    {
        ValidateComment(text, property);
        Id = id;
        Text = text;
        Property = property;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private Comment(string text, Property property):this()
    {
        ValidateComment(text, property);
        Text = text;
        Property = property;

    }

    public static Comment Create(string text, Property property)
    {
        return new Comment(text, property);
    }

    public static Comment Update(string newText, Property newProperty)
    {
        return new Comment(newText, newProperty);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(Comment comment)
    {
        comment.IsDeleted = false;
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


