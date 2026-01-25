using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string? Url { get; set; }

    public string? Icon { get; set; }

    public int? ParentId { get; set; }

    public int? OrderPosition { get; set; }

    public bool RowStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Menu> InverseParent { get; set; } = new List<Menu>();

    public virtual Menu? Parent { get; set; }
}
