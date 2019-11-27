using Microsoft.AspNetCore.Mvc;
using VWAT.Services;

namespace VWAT.Controllers
{
    public class XssController : Controller
    {
        private CommentService _service;

        public XssController(CommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult XssReflected()
        {
            ViewBag.Comments = _service.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveReflected(string comment)
        {
            ViewBag.Comment = comment;
            return View("XssReflected");
        }

        [HttpGet]
        public IActionResult XssStorage()
        {
            ViewBag.Comments = _service.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveStorage(string comment)
        {
            _service.Add(comment);
            ViewBag.Comments = _service.GetAll();
            return View("XssStorage");
        }
    }
}