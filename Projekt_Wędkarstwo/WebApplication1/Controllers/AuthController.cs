using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AuthController : ControllerBase
    {


        
        [HttpGet("register")]
        public IActionResult Register()
        {
            return Ok("Register endpoint");
        }


    }
}
