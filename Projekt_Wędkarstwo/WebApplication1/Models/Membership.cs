using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required decimal DiscountPercentage { get; set; }

        [Required]
        public required bool IncludesMysteryBox { get; set; }
    }
}
