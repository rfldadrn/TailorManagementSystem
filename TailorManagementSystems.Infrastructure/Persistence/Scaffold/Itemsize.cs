using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Itemsize
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public string Name { get; set; } = null!;

    public sbyte? RowStatus { get; set; }

    public virtual ItemManagement Item { get; set; } = null!;

    public virtual ICollection<Itemsizecustomer> Itemsizecustomers { get; set; } = new List<Itemsizecustomer>();
}
