using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public required List<CreateOrderitemDto> Items { get; set; } = new();
    }
}
