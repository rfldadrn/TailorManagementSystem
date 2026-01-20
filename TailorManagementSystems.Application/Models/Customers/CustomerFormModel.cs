
using System.ComponentModel.DataAnnotations;

namespace TailorManagementSystems.Application.Models.Customers
{
    public class CustomerFormModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama Pelanggan wajib diisi")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Nomor telepon wajib diisi")]
        [Phone(ErrorMessage = "Format nomor telepon tidak valid")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string? Email { get; set; }

        public string? Gender { get; set; }

        public bool? RowStatus { get; set; }
    }

    public enum Gender
    {
        Pria,
        Wanita
    }
}
