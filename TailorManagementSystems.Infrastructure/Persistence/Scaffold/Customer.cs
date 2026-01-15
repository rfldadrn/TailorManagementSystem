using System;
using System.Collections.Generic;
using TailorManagementSystems.Application.Models.Customers;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public Gender Gender { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
