using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VWAT.Models;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace VWAT.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => _logger = logger;

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy() => View();

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string name, string password)
    {
      var claims = new List<Claim>() { new Claim(ClaimTypes.Role, "Administrator"), new Claim(ClaimTypes.Name, name) };
      var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
      // Challenge(CookieAuthenticationDefaults.AuthenticationScheme);
      return SignIn(claimsPrincipal, new AuthenticationProperties(), CookieAuthenticationDefaults.AuthenticationScheme);
      // return View("Index");
    }

    public IActionResult Logout()
    {
      return SignOut(CookieAuthenticationDefaults.AuthenticationScheme);
      // return View("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}

// https://developer.okta.com/blog/2019/11/15/aspnet-core-3-mvc-secure-authentication