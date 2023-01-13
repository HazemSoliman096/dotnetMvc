public class Employee
{
  public int Id { get; set; }
  public int DepartmentId { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Designation { get; set; } = string.Empty;

  public Department Department { get; set; }
}