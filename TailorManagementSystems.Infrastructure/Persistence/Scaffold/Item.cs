using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? CustomerPrice { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Itememployeefee> Itememployeefees { get; set; } = new List<Itememployeefee>();

    public virtual ICollection<Itemsize> Itemsizes { get; set; } = new List<Itemsize>();

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
