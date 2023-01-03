using System.ComponentModel.DataAnnotations;
namespace CrudRepoApp.Models
{
  public class Employee
  {
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;

    [Range(16, 60, ErrorMessage = "Age 16-60 only")]
    public int Age { get; set; } = 0;

    [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid, enter like # or #.##")]
    public decimal Salary { get; set; } = 0;
    [RegularExpression(@"^[MF]+$", ErrorMessage = "Select any one option")]
    public Char Sex { get; set; }
  }
}