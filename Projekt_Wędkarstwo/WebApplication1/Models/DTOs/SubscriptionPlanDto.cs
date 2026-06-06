using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class SubscriptionPlanDto
    {
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }

        [Required]
        public required int DurationDays { get; set; }

        [Required]
        public required decimal Price { get; set; }
    }
}
