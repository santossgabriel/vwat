using System.Collections.Generic;
using System.Linq;

namespace VWAT.Models
{
  public class CommentService
  {
    private List<CommentViewModel> _comments;

    public CommentService()
    {
      _comments = new List<CommentViewModel>();
    }

    public void Add(string description)
    {
      if (!string.IsNullOrEmpty(description))
      {
        int id = _comments.Any() ? _comments.Select(p => p.Id).Max() : 1;
        _comments.Add(new CommentViewModel() { Id = id, Description = description });
      }
    }

    public List<CommentViewModel> GetAll()
    {
      return _comments.ToList();
    }

    public void Remove(int id)
    {
      _comments.Remove(_comments.Find(p => p.Id == id));
    }
  }
}