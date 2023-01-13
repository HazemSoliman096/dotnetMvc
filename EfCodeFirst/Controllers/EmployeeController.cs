using EfCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EfCodeFirst.Controllers
{
  public class EmployeeController : Controller
  {
    private CompanyContext context;
    public EmployeeController(CompanyContext cc)
    {
      context = cc;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Create()
    {
      List<SelectListItem> dept = new List<SelectListItem>();
      dept = context.Department.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
      ViewBag.Department = dept;

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employee emp)
    {
      context.Add(emp);
      await context.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}