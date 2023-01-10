using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCodeFirst.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private CompanyContext companyContext;

    public HomeController(ILogger<HomeController> logger, CompanyContext context)
    {
        companyContext = context;
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

    public IActionResult CreateInformation() {
      var info = new Information()
      {
        Name = "Yogi",
        License = "YYY",
        Revenue = 1000,
        Established = Convert.ToDateTime("2023/01/10")
      };
      companyContext.Entry(info).State = EntityState.Added;
      companyContext.SaveChanges();
      return View();
    }
}
