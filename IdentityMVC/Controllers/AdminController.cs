using IdentityMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IdentityMVC.Controllers
{
  public class AdminController : Controller
  {
    private readonly UserManager<AppUser> userManager;
    private readonly IPasswordHasher<AppUser> passwordHasher;
    private IPasswordValidator<AppUser> passwordValidator;

    public AdminController(UserManager<AppUser> userMgr, IPasswordHasher<AppUser> ipasswordHasher, IPasswordValidator<AppUser> ipasswordValidator)
    {
      userManager = userMgr;
      passwordHasher = ipasswordHasher;
      passwordValidator = ipasswordValidator;
    }

    public IActionResult Index()
    {
      return View(userManager.Users);
    }

    public ViewResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
      if (ModelState.IsValid)
      {
        AppUser appUser = new()
        {
          UserName = user.Name,
          Email = user.Email
        };

        IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
        }
      }

      return View(user);
    }

    public async Task<IActionResult> Update(string id)
    {
      AppUser user = await userManager.FindByIdAsync(id);
      if (user != null)
        return View(user);
      else
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Update(string id, string email, string password)
    {
      AppUser user = await userManager.FindByIdAsync(id);

      if (user == null)
      {
        ModelState.AddModelError("", "User Not Found");
      }
      else
      {

        if (string.IsNullOrEmpty(email))
        {
          ModelState.AddModelError("", "Email can't be empty");
        }
        else
        {
          user.Email = email;
        }

        if (string.IsNullOrEmpty(password))
        {
          ModelState.AddModelError("", "password can't be empty");
        }
        else
        {
          IdentityResult validPass = await passwordValidator.ValidateAsync(userManager, user, password);
          if (validPass.Succeeded)
          {
            user.PasswordHash = passwordHasher.HashPassword(user, password);
          }
          else
          {
            Errors(validPass);
          }
        }

        if (!string.IsNullOrEmpty(email) & !string.IsNullOrEmpty(password))
        {
          IdentityResult result = await userManager.UpdateAsync(user);
          if (result.Succeeded)
          {
            return RedirectToAction("Index");
          }
          else
          {
            Errors(result);
          }
        }
      }
      return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
      AppUser user = await userManager.FindByIdAsync(id);
      if (user != null)
      {
        IdentityResult result = await userManager.DeleteAsync(user);

        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          Errors(result);
        }
      }
      else
      {
        ModelState.AddModelError("", "User Not Found");
      }
      return View("Index", userManager.Users);
    }
    private void Errors(IdentityResult result)
    {
      foreach (IdentityError error in result.Errors)
      {
        ModelState.AddModelError("", error.Description);
      }
    }
  }
}