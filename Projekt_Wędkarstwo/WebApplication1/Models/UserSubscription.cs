using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserSubscription
    {
        public int Id { get; set; }

        [Required]
        public required int UserId { get; set; }

        public User User { get; set; } = null!;

        [Required]
        public required int SubscriptionPlanId { get; set; }

        public SubscriptionPlan SubscriptionPlan { get; set; } = null!;

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }
    }
}
