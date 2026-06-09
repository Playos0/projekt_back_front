using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class MembershipDto
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;

        [Required]
        public required DateTime StartDate { get; set; }

        [Required]
        public required DateTime EndDate { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        [Required]
        public required bool AutoRenewal { get; set; }

        [Required]
        public required decimal DiscountPercentage { get; set; }

        [Required]
        public required bool IncludesMysteryBox { get; set; }
    }
}
