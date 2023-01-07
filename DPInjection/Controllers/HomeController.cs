using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DPInjection.Models;

namespace DPInjection.Controllers;

public class HomeController : Controller
{

  private IRepository repository;
  private ProductSum productSum;
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger, IRepository repo, ProductSum pSum)
  {
    _logger = logger;
    repository = repo;
    productSum = pSum;
  }

  public IActionResult Index()
  {
    ViewBag.HomeControllerGuid = repository.ToString();
    ViewBag.TotalGuid = productSum.Repository.ToString();
    ViewBag.Total = productSum.total;
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
