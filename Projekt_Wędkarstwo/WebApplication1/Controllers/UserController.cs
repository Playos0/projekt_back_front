using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController: ControllerBase
    {
        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            return Ok(new { Email = email });
        }
    }
}
