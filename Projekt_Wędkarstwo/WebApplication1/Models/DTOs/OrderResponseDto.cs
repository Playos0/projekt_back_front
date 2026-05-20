using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace WebApplication1.Models.DTOs
{
    public class OrderResponseDto
    {
        [Required]
        public required int OrderId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public required string Status { get; set; } = string.Empty;

        [Required]
        public required DateTime CreatedAt { get; set; }
    }
}
