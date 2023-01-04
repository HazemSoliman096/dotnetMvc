using Dotnetconfig.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{

    TotalUsers totalUsers;

    public HomeController(TotalUsers tu)
    {
        totalUsers = tu;
    }

    public string Index()
    {
        return "Total Users = " + totalUsers.TUsers();
    }

    public IActionResult Error()
    {
        return View();
    }
}
