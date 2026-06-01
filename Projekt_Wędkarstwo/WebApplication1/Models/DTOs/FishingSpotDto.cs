using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class FishingSpotDto
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public required string Location { get; set; }

        [Required]
        public required decimal DayPassPrice { get; set; }

        [Required]
        public required bool SubscriptionAvailable { get; set; }
    }
}
