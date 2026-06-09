using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class BuyMembershipDto
    {
        [Required]
        public required int MembershipId { get; set; }

        [Required]
        public required int DurationInMonths { get; set; }

        [Required]
        public required bool AutoRenew { get; set; }
    }
}


