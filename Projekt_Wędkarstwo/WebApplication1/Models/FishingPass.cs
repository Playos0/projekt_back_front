using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class FishingPass
    {
        public int Id { get; set; }

        [Required]
        public required int UserId { get; set; }

        public User User { get; set; } = null!;

        [Required]
        public required DateTime ValidDate { get; set; }

        [Required]
        public required decimal Price { get; set; }

        [Required]
        public required DateTime PurchaseDate { get; set; }
    }
}
