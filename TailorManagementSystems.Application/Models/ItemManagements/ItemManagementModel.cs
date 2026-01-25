using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.Models.ItemManagement
{
    public class ItemManagementModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? CustomerPrice { get; set; }

        public int? RowStatus { get; set; }
    }
}
