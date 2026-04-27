using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;
using WebApplication1.Models.DTOs;


namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDto dto)
        {   
            var email = dto.Email.ToLowerInvariant();

            var result = _authService.Register(dto);

            if (!result)
            {
                return BadRequest("User already exists");
            }

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            var email = dto.Email.ToLowerInvariant();

            var token = _authService.Login(email, dto.Password);

            if(token == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok(new { Token = token });
        }

    }
}
