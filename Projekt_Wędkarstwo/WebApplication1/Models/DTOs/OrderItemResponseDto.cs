using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class OrderItemResponseDto
    {
        [Required]
        public required int ProductId { get; set; }

        [Required]
        public required string ProductName { get; set; } = String.Empty;

        [Required]
        public required int Quantity { get; set; }

        [Required]
        public required decimal UnitPrice { get; set; }
    }
}
