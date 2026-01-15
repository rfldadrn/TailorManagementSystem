using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string Password { get; set; } = null!;

    public string? Avatar { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Mappingrole> Mappingroles { get; set; } = new List<Mappingrole>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
