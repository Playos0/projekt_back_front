using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        public string? Address { get; set; }

        [Required]
        public required string Password { get; set; }

    }
}
