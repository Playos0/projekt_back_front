using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class UserController: ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var userIdClaim  = User.FindAll(ClaimTypes.NameIdentifier).FirstOrDefault();

            if (userIdClaim == null) 
            {
                return Unauthorized("User ID claim not found");
            };

            var user = _context.Users.FirstOrDefault(u => u.Id == int.Parse(userIdClaim.Value));

            if(user == null)
            {
                return NotFound("User not found");
            }

            var response = new UserMeResponseDto
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Address = new AddressDto
                {
                    City = user.Address.City,
                    Street = user.Address.Street,
                    HouseNumber = user.Address.HouseNumber,
                    PostalCode = user.Address.PostalCode
                }
            };

            return Ok(response);

        }
    }
}
