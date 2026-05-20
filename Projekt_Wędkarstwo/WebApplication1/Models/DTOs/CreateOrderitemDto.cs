using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class CreateOrderitemDto
    {
        [Required]
        public required int ProductId { get; set; }

        [Required]
        [Range(1,100)]
        public required int Quantity { get; set; }
    }
}
