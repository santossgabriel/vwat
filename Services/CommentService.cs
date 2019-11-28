using System.Collections.Generic;
using System.Linq;
using VWAT.Models;

namespace VWAT.Services
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

    public List<Comment> GetAll()
    {
      return _context.Comment.ToList();
    }

    public void Remove(int id)
    {
      _context.Comment.Remove(_context.Comment.Find(id));
      _context.SaveChanges();
    }
  }
}