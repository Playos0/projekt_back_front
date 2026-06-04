using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        public string? Description { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string? Category { get; set; }

        [MinLength(5)]
        [MaxLength(200)]
        public string? ImageUrl { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public required decimal Price { get; set; }

        [Required]
        [Range(0, 999)]
        public required int Stock { get; set; }
    }
}
