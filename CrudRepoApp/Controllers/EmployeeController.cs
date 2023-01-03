using CrudRepoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepoApp.Controllers
{
  public class EmployeeController : Controller
  {
    public IActionResult Index()
    {
      return View(Repository.AllEmployees);
    }

    // HTTP Get
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
      if (ModelState.IsValid)
      {
        Repository.create(employee);
        return View("Thanks", employee);
      }
      else
      {
        return View();
      }
    }

    public IActionResult Update(string empname)
    {
      var employee = Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault();
      return View(employee);
    }

    [HttpPost]
    public IActionResult Update(Employee employee, string empname)
    {
      if (ModelState.IsValid)
      {
        var Oldemployee = Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault();
        Oldemployee.Name = employee.Name;
        Oldemployee.Age = employee.Age;
        Oldemployee.Department = employee.Department;
        Oldemployee.Salary = employee.Salary;
        Oldemployee.Sex = employee.Sex;
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }

    [HttpPost]
    public IActionResult Delete(string empname)
    {
      var employee = Repository.AllEmployees.Where(e => e.Name == empname).FirstOrDefault();
      Repository.Delete(employee);
      return RedirectToAction("Index");
    }
  }
}