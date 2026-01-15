using System;
using System.Collections.Generic;

namespace TailorManagementSystems.Infrastructure.Persistence.Scaffold;

public partial class Transaction
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int? AgencyId { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime? CompletionDate { get; set; }

    public decimal? Amount { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal? BalanceDue { get; set; }

    public string? Note { get; set; }

    public int? PaymentTypeId { get; set; }

    public int? CreatedBy { get; set; }

    public sbyte? RowStatus { get; set; }

    public virtual Agency? Agency { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Paymenttype? PaymentType { get; set; }

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
