using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public required string Name { get; set;}

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public required string Password { get; set; }

        [Required]
        public required AddressDto Address { get; set; }

    }
}
