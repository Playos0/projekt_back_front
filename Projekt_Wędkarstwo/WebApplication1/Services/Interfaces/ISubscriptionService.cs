using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionPlanDto>> GetPlansAsync(int fishingSpotId);
        Task BuySubscriptionAsync(int planId, ClaimsPrincipal userClaims);
        Task<IEnumerable<UserSubscriptionDto>> GetMySubscriptionsAsync(ClaimsPrincipal userClaims);
    }
}
