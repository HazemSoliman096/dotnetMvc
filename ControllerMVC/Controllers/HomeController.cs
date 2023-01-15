using Microsoft.AspNetCore.Mvc;
namespace ControllerMVC.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult ReceivedDataByRequest() {
    string? name = Request.Form["name"];
    string? sex = Request.Form["sex"];
    return View("ReceivedDataByRequest", $"{name} sex is {sex}");
  }
}
