using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class UserSubscriptionDto
    {
        public int Id { get; set; }
        
        [Required]
        public required string FishingSpotName { get; set; }
        
        [Required]
        public required string PlanName { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
