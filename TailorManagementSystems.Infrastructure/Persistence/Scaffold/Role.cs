using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Mappingrole> Mappingroles { get; set; } = new List<Mappingrole>();
}
