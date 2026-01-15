using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Agency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? TargetDate { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
