using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionPlanDto>> GetPlansAsync(int fishingSpotId);
        Task BuySubscriptionAsync(int planId, ClaimsPrincipal userClaims);
        Task<IEnumerable<UserSubscriptionDto>> GetMySubscriptionsAsync(ClaimsPrincipal userClaims);
    }
}
