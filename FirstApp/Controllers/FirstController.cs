using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers {
  public class FirstController : Controller {
    public string Index() {
      return "Hello, World!";
    }

    public IActionResult Hello() {
      return View();
    }
  }
}