using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class SubscriptionService: ISubscriptionService
    {
        private readonly AppDbContext _context;

        public SubscriptionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubscriptionPlanDto>> GetPlansAsync(int fishingSpotId)
        {
            return await _context.SubscriptionPlans
                .Where(p => p.FishingSpotId == fishingSpotId)
                .Select(p => new SubscriptionPlanDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    DurationDays = p.DurationInDays,
                    Price = p.Price
                }).ToListAsync();
        }

        public async Task BuySubscriptionAsync(int planId, ClaimsPrincipal userClaims)
        {
            var email = userClaims.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var plan = await _context.SubscriptionPlans.FirstOrDefaultAsync(p => p.Id == planId);

            if (plan == null)
            {
                throw new InvalidOperationException("Subscription plan not found");
            }

            var subscription = new UserSubscription
            {
                UserId = user.Id,
                SubscriptionPlanId = plan.Id,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(plan.DurationInDays)
            };

            _context.UserSubscriptions.Add(subscription);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserSubscriptionDto>> GetMySubscriptionsAsync(ClaimsPrincipal userClaims)
        {
            var email = userClaims.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return await _context.UserSubscriptions
                .Where(us => us.UserId == user.Id)
                .Select(s => new UserSubscriptionDto
                {
                    Id = s.Id,
                    FishingSpotName = s.SubscriptionPlan.FishingSpot.Name,
                    PlanName = s.SubscriptionPlan.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    IsActive = s.EndDate > DateTime.UtcNow
                }).ToListAsync();
        }
    }
}
