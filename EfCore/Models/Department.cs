using System.Collections.Generic;

namespace EfCore.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
