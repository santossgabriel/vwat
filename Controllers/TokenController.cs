using Microsoft.AspNetCore.Mvc;
using VWAT.Models;

namespace VWAT.Controllers
{
  [Route("api/[controller]")]
  public class TokenController : Controller
  {
    public TokenController() { }

    [HttpPost]
    public IActionResult Post([FromBody]User user)
    {
      return Ok(new { name = user.Name, password = user.Password });
    }
  }
}