using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class AddressDto
    {
        [Required]
        [MaxLength(100)]
        public required string City { get; set; }

        [Required]
        [MaxLength(150)]
        public required string Street { get; set; }

        [Required]
        [MaxLength(10)]
        public required string HouseNumber { get; set; }

        [Required]
        [MaxLength(7)]
        [RegularExpression(@"^\d{2}(-\d{3})?$", ErrorMessage = "Invalid postal code format")]
        public required string PostalCode { get; set; }
    }
}
