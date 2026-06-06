using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class FishingPassDto
    {
        public int Id { get; set; }

        [Required]
        public required string FishingSpotName { get; set; }

        [Required]
        public required DateTime ValidDate { get; set; }
        
        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required DateTime PurchaseDate { get; set; }
    }
}
