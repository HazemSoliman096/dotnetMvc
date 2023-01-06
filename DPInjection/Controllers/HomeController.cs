using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DPInjection.Models;

namespace DPInjection.Controllers;

public class HomeController : Controller
{

  private IRepository repository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IRepository repo)
    {
        _logger = logger;
        repository = repo;
    }

    public IActionResult Index()
    {
        return View(repository.Products);
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
}
