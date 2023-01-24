using System.Security.Claims;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookiesMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace CookiesMVC.Controllers;

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

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  public IActionResult Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(string username, string password, string returnUrl)
  {
    if ((username == "Admin") && (password == "Admin"))
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, username)
      };

      var claimsIdentity = new ClaimsIdentity(claims, "Login");
      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme
      , new ClaimsPrincipal(claimsIdentity));
      return Redirect(returnUrl == null ? "/Secured" : returnUrl);
    }
    else
    {
      return View();
    }
  }

  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    await HttpContext.SignOutAsync();
    return RedirectToAction("Index", "Home");
  }
}
