﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using University.Services;
using University.Models;

namespace University.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly UserService _userService;

    public HomeController(ILogger<HomeController> logger, UserService userService)
    {
      _logger = logger;
      _userService = userService;
    }

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
      var login = _userService.Login(name, password);

      if (login is null)
      {
        return View("Index");
      }

      var claims = new List<Claim>() { new Claim(ClaimTypes.Role, "Administrator"), new Claim(ClaimTypes.Name, login.Email) };
      var identity = new ClaimsIdentity(claims, "User Identity");
      var userPrincipal = new ClaimsPrincipal(new[] { identity });

      HttpContext.SignInAsync(userPrincipal);
      return RedirectToAction("Index", "Home");
    }

    public IActionResult Logout()
    {
      var name = User.Identity.Name;
      HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}