using EfCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCodeFirst.Controllers
{
  public class DepartmentController : Controller
  {
    private CompanyContext context;
    public DepartmentController(CompanyContext cc)
    {
      context = cc;
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Department dept)
    {
      context.Add(dept);
      await context.SaveChangesAsync();
      return View();
    }
  }
}