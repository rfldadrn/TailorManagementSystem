using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public DateOnly? JoinDate { get; set; }

    public int? EmployeeTypeId { get; set; }

    public string? Avatar { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual Employeetype? EmployeeType { get; set; }

    public virtual ICollection<Employeetask> Employeetasks { get; set; } = new List<Employeetask>();
}
