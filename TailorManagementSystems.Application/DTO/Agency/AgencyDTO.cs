using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorManagementSystems.Application.DTO.Agency
{
    public class AgencyDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? TargetDate { get; set; }

        public bool? RowStatus { get; set; }
    }
}
