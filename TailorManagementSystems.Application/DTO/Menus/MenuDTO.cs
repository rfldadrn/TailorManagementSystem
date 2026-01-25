using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.DTO.Menus
{
    public class MenuDTO
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

        public virtual ICollection<MenuDTO> InverseParent { get; set; } = new List<MenuDTO>();

        public virtual List<MenuDTO>? Parent { get; set; }
    }
}
