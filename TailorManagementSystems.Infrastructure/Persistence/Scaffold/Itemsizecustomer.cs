using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Itemsizecustomer
{
    public int Id { get; set; }

    public int ItemSizeId { get; set; }

    public string? Value { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual Itemsize ItemSize { get; set; } = null!;

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
