using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Employeetask
{
    public int Id { get; set; }

    public int TransactionItemId { get; set; }

    public int EmployeeId { get; set; }

    public int? ItemEmployeeFeeId { get; set; }

    public string? Note { get; set; }

    public bool? IsDone { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Itememployeefee? ItemEmployeeFee { get; set; }

    public virtual Transactionitem TransactionItem { get; set; } = null!;
}
