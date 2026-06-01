using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        [Required]
        public required int FishingSpotId { get; set; }

        public FishingSpot FishingSpot { get; set; } = null!;

        [Required]
        public required string Name { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
