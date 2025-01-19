
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Interfaces;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class CommentRepository : ICommentRepository
{
    private readonly Database _db;
    
    public CommentRepository(Database database)
    {
        _db = database;
        
    }
    public Comment Add(Comment comment)
    {
        _db.Comments.Add(comment);
        return comment;
    }
    public List<Comment> GetAll()
    {
        var allComments = new List<Comment>();
        foreach (var comment in _db.Comments)
        {
            allComments.Add(comment);
        }
        return allComments;
    }

    public Comment GetById(int id)
    {
        
        foreach (var comment in _db.Comments)
        {
            if (comment.Id == id)
            {
                return comment;

            }
        }
        throw new KeyNotFoundException($"Comment with ID {id} was not found.");

    }

    public Comment Update(Comment comment)
    {
        var allComments = _db.Comments.ToList();
        foreach (var existingComment in allComments)
        {
            if (existingComment.Id == comment.Id)
            {
                existingComment.UpdateComment(comment.Text, comment.Property, comment.Client);
                return existingComment;
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }

    public Comment Delete(Comment comment)
    {
        var allComments = _db.Comments.ToList();
        foreach (var existingComment in allComments)
        {
            if (existingComment.Id == comment.Id)
            {
                _db.Comments.Remove(existingComment);
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }

    public Comment Delete(int id)
    {
        var allComments = _db.Comments.ToList();
        foreach (var existingComment in allComments)
        {
            if (existingComment.Id == id)
            {
                _db.Comments.Remove(existingComment);

            }
        }
        throw new KeyNotFoundException($"Manager with ID {id} was not found.");
    }

    public List<Comment> GetCommentsByClientId(int clientId)
    {
        var commentsByClient = new List<Comment>();
        foreach (var comment in _db.Comments)
        { 
            if (comment.Client.Id == clientId)
            {
                commentsByClient.Add(comment);
            }
        }
        return commentsByClient;
    }

    public List<Comment> GetCommentsByPropertyId(int propertyId)
    {
        var commentsByProperty = new List<Comment>();
        foreach (var comment in _db.Comments)
        {
            if (comment.Client.Id == propertyId)
            {
                commentsByProperty.Add(comment);
            }
        }
        return commentsByProperty;
    }
}
