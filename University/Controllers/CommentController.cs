using Microsoft.AspNetCore.Mvc;
using University.Models;
using University.Services;

namespace University.Controllers
{
  [Route("api/[controller]")]
  public class CommentController : Controller
  {
    private CommentService _service;
    public CommentController(CommentService service) => _service = service;

    [HttpPost]
    public IActionResult Post([FromBody]Comment comment)
    {
      if (!string.IsNullOrEmpty(comment?.Description))
      {
        _service.Add(comment.Description);
        return Ok();
      }
      else
        return UnprocessableEntity("Invalid request");
    }

    [HttpGet]
    public IActionResult Get() => Ok(_service.GetAll());

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      _service.Remove(id);
      return Ok();
    }
  }
}