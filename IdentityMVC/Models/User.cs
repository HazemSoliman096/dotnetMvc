using System.ComponentModel.DataAnnotations;

namespace IdentityMVC.Models
{
  public class User
  {
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
  }
}