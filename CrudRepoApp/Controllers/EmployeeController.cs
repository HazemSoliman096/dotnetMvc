using CrudRepoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepoApp.Controllers
{
  public class EmployeeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    // HTTP Get
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
      Repository.create(employee);
      return View("Thanks", employee);
    }
  }
}