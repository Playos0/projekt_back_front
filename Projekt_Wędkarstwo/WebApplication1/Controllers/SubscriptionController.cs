using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet("plans/{fishingSpotId}")]
        public async Task<IActionResult> GetPlans(int fishingSpotId)
        {
            return Ok(await _subscriptionService.GetPlansAsync(fishingSpotId));
        }

        [HttpPost("buy/{planId}")]  
        public async Task<IActionResult> BuySubscription(int planId)
        {
            await _subscriptionService.BuySubscriptionAsync(planId, User);
            return Ok(new { message = "Subscription purchased successfully" });
        }

        [HttpGet("my")]
        [Authorize]
        public async Task<IActionResult> my()
        {
            return Ok(await _subscriptionService.GetMySubscriptionsAsync(User));
        }
    }
}
