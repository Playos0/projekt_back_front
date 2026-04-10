using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }


    }
}
