using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TailorManagementSystems.Application.DTO.Customers
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public Gender Gender { get; set; }

        public sbyte? RowStatus { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }

    public enum Gender
    {
        Pria = 1,
        Wanita = 2
    }
}
