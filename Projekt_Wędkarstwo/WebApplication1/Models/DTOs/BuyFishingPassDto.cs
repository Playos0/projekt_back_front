using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class BuyFishingPassDto
    {
        [Required]
        public required int FishingSpotId { get; set; }

        [Required]
        public required DateTime FishingDate { get; set; }
    }
}
