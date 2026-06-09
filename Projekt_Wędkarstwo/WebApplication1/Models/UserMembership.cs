using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserMembership
    {
        public int Id { get; set; }

        [Required]
        public required int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        public required int MembershipId { get; set; }

        public Membership Membership { get; set; } = null!;

        [Required]
        public required int DurationInMonths { get; set; }

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        [Required]
        public bool AutoRenew { get; set; }
    }
}
