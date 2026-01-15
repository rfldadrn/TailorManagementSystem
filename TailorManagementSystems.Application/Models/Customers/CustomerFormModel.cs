
namespace TailorManagementSystems.Application.Models.Customers
{
    public class CustomerFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public Gender Gender { get; set; }

        public sbyte? RowStatus { get; set; }
    }

    public enum Gender
    {
        Pria,
        Wanita
    }
}
