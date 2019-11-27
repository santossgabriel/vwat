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
        _context.Comments.Add(new Comment() { Description = description });
        _context.SaveChanges();
      }
    }

    public List<Comment> GetAll()
    {
      return _context.Comments.ToList();
    }

    public void Remove(int id)
    {
      _context.Comments.Remove(_context.Comments.Find(id));
      _context.SaveChanges();
    }
  }
}