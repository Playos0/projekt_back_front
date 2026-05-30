using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Address
    {
        [Required]
        public required string City { get; set; }

        [Required]
        public required string Street { get; set; }

        [Required]
        public required string HouseNumber { get; set; }

        [Required]

        public required string PostalCode { get; set; }

        
    }
}
