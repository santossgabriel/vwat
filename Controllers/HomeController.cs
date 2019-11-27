using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VWAT.Models;

namespace VWAT.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    public IActionResult Login()
    {
      Challenge(CookieAuthenticationDefaults.AuthenticationScheme);
      return View("Index");
    }

    public IActionResult Logout()
    {
      SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
      return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

// https://developer.okta.com/blog/2019/11/15/aspnet-core-3-mvc-secure-authentication