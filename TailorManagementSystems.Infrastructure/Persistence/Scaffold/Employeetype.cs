using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Employeetype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Itememployeefee> Itememployeefees { get; set; } = new List<Itememployeefee>();
}
