using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet("memberships")]
        public async Task<IActionResult> GetMemberships()
        {
            var memberships = await _membershipService.GetMembershipsAsync();
            return Ok(memberships);
        }

        [HttpPost("buy")]
        [Authorize]
        public async Task<IActionResult> BuyMembership([FromBody] BuyMembershipDto dto)
        {
            await _membershipService.BuyMembershipAsync(dto, User);
            return Ok(new { message = "Membership purchased successfully" });
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<IActionResult> My()
        {
            var result = await _membershipService.GetMyMembershipsAsync(User);

            if(result == null)
            {
                return NotFound(new { message = "No memberships found for the user" });
            }
            return Ok(result);
        }
    }
}
