using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Itememployeefee
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int EmployeeTypeId { get; set; }

    public decimal Fee { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual Employeetype EmployeeType { get; set; } = null!;

    public virtual ICollection<Employeetask> Employeetasks { get; set; } = new List<Employeetask>();

    public virtual Item Item { get; set; } = null!;
}
