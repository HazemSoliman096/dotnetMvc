using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class FirstController : Controller
    {
        public string Index()
        {
            return "Hello, World!";
        }

        public IActionResult Hello()
        {
            ViewBag.Message = "Hello Message";
            return View();
        }

        public IActionResult Info()
        {
            Person person = new Person();
            person.name = "Hazem";
            person.Age = 26;
            person.Location = "Egypt/Alexandria";
            return View(person);
        }
    }
}
