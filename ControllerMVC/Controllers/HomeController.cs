using ControllerMVC.Models;
using Microsoft.AspNetCore.Mvc;
namespace ControllerMVC.Controllers;

public class HomeController : Controller
{
  private IWebHostEnvironment webHostEnvironment;
  public HomeController(IWebHostEnvironment environment)
  {
    webHostEnvironment = environment;
  }
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult ReceivedDataByRequest()
  {
    string? name = Request.Form["name"];
    string? sex = Request.Form["sex"];
    return View("ReceivedDataByRequest", $"{name} sex is {sex}");
  }

  public IActionResult ReceivedDataByParameter(string name, string sex)
  {
    return View("ReceivedDataByParameter", $"{name} sex is {sex}");
  }

  public IActionResult ReceivedDataByPerson(Person person)
  {
    return View("ReceivedDataByParameter", person);
  }

  [HttpPost]
  public async Task<IActionResult> Index(IFormFile photo)
  {
    using (FileStream stream = new(Path.Combine(webHostEnvironment.WebRootPath, photo.FileName), FileMode.Create))
    {
      await photo.CopyToAsync(stream);
    }
    return View();
  }
}
