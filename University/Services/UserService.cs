using System.Linq;
using University.Models;

namespace University.Services
{
  public class UserService
  {
    private AppDbContext _context;
    
    public UserService(AppDbContext context)
    {
      _context = context;
    }

    public User Login(string name, string password)
    {
      return _context.User.FirstOrDefault(p => p.Name == name && p.Password == password)?.WithoutPassword();
    }
  }
}