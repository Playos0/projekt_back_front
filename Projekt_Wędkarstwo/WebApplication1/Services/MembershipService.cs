using WebApplication1.Data;
using WebApplication1.Services.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly AppDbContext _context;

        public MembershipService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Membership>> GetMembershipsAsync()
        {
            return await _context.Memberships.ToListAsync();
        }

        public async Task BuyMembershipAsync(BuyMembershipDto dto, ClaimsPrincipal userClaim)
        {
            var email = userClaim.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            //buying when active lock 
            var hasActiveMembership = await _context.UserMemberships
                .AnyAsync(m => m.UserId == user.Id && m.IsActive);

            if (hasActiveMembership)
            {
                throw new Exception("User already has active membership");
            }


            var membership = await _context.Memberships.FirstOrDefaultAsync(m => m.Id == dto.MembershipId);

            if (membership == null)
            {
                throw new Exception("Membership not found");
            }

            var startDate = DateTime.UtcNow;
            var endDate = startDate.AddMonths(dto.DurationInMonths);

            var userMembership = new UserMembership
            {
                UserId = user.Id,
                MembershipId = membership.Id,
                StartDate = startDate,
                EndDate = endDate,
                DurationInMonths = dto.DurationInMonths,
                IsActive = true,
                AutoRenew = dto.AutoRenew
                
            };

            _context.UserMemberships.Add(userMembership);
            await _context.SaveChangesAsync();
        }

        public async Task<MembershipDto?> GetMyMembershipsAsync(ClaimsPrincipal userClaim)
        {
            var email = userClaim.FindFirstValue(ClaimTypes.Email);

            var user  = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var membership = await _context.UserMemberships
                .Include(m => m.Membership)
                .FirstOrDefaultAsync(m => m.UserId == user.Id && m.IsActive);

            if (membership == null)
            {
                return null;
            }

            bool stateChaned = false;

            if (membership.EndDate <= DateTime.UtcNow)
            {
                if (membership.AutoRenew)
                {
                    membership.EndDate = membership.EndDate.AddMonths(membership.DurationInMonths);
                    membership.StartDate = DateTime.UtcNow;

                    stateChaned = true;
                }
                else
                {
                    membership.IsActive = false;
                    stateChaned = true;
                }
            }

            if(stateChaned)
            {
                await _context.SaveChangesAsync();
            }

            if (!membership.IsActive)
            {
                return null;
            }

            return new MembershipDto
            {
                Name = membership.Membership.Name,
                StartDate = membership.StartDate,
                EndDate = membership.EndDate,
                IsActive = membership.IsActive,
                AutoRenewal = membership.AutoRenew,
                DiscountPercentage = membership.Membership.DiscountPercentage,
                IncludesMysteryBox = membership.Membership.IncludesMysteryBox
            };
        }

    }
}
