using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        [Required]
        public required int Quantity { get; set; }

        [Required]
        public required decimal UnitPrice { get; set; }
    }
}
