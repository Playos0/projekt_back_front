using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

       [Required]  
        public required string HashedPassword { get; set; }

        [Required]
        public required Address Address { get; set; }

    }
}
