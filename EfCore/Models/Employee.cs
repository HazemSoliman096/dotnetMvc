using System;
using System.Collections.Generic;

namespace EfCore.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Designation { get; set; } = string.Empty;

    public int Departmentid { get; set; }

    public virtual Department Department { get; set; } = null;
}
