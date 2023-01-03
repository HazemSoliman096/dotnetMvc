namespace CrudRepoApp.Models {
  public class Employee {
    public string Name { get; set;} = string.Empty;
    public string Department { get; set;} = string.Empty;
    public int Age { get; set;} = 0;
    public decimal Salary { get; set;} = 0;
    public Char Sex { get; set;}
  }
}