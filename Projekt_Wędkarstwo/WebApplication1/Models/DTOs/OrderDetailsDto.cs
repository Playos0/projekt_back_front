using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class OrderDetailsDto
    {
        [Required]
        public required int OrderId { get; set; }

        [Required]
        public required decimal TotalPrice { get; set; }

        public string Status { get; set; } = String.Empty;

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required List<OrderItemResponseDto> Items { get; set; } = new();
    }
}
