using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        int Id { get; set; }

        [Required]
        public required int UserId { get; set; }

        public User User { get; set; } = null!;

        [Required]
        public required Decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending";

        [Required]
        public required List<OrderItem> OrderItems { get; set; } = new();
    }
}
