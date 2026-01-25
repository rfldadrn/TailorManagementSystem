
using System.ComponentModel.DataAnnotations;

namespace TailorManagementSystems.Application.Models.Payment_Types
{
    public class Payment_TypeFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama Payment Type wajib diisi")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool RowStatus { get; set; }
    }

}
