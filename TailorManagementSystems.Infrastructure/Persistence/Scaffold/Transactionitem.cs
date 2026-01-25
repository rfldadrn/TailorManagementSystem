using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Transactionitem
{
    public int Id { get; set; }

    public int TransactionId { get; set; }

    public int ItemId { get; set; }

    public int? ItemSizeCustomerId { get; set; }

    public decimal? CustomerPrice { get; set; }

    public string? Note { get; set; }

    public int? StatusTransactionId { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual ICollection<Employeetask> Employeetasks { get; set; } = new List<Employeetask>();

    public virtual ItemManagement Item { get; set; } = null!;

    public virtual Itemsizecustomer? ItemSizeCustomer { get; set; }

    public virtual Statustransaction? StatusTransaction { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;
}
