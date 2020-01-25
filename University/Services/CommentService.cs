using System.Collections.Generic;
using University.Models;

namespace University.Services
{
  public class CommentService
  {
    private AppDbContext _context;
    
    public CommentService(AppDbContext context)
    {
      _context = context;
    }

    public void Add(string description)
    {
      if (!string.IsNullOrEmpty(description))
      {
        _context.Comment.Add(new Comment() { Description = description });
        _context.SaveChanges();
      }
    }

    public IEnumerable<Comment> GetAll()
    {
      return _context.Comment;
    }

    public void Remove(int id)
    {
      _context.Comment.Remove(_context.Comment.Find(id));
      _context.SaveChanges();
    }
  }
}