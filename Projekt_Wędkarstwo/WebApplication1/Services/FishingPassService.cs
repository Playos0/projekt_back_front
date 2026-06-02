using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class FishingPassService: IFishingPassService
    {
        public readonly AppDbContext _context;

        public FishingPassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task BuyPassAsync(BuyFishingPassDto dto, ClaimsPrincipal userClaims)
        {
            var email = userClaims.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var spot = await _context.FishingSpots.FirstOrDefaultAsync(s => s.Id == dto.FishingSpotId);

            if (spot == null)
            {
                throw new Exception("Fishing spot not found");
            }

            var pass = new FishingPass
            {
                UserId = user.Id,
                FishingSpotId = spot.Id,
                ValidDate = dto.FishingDate,
                PurchaseDate = DateTime.UtcNow,
                Price = spot.DayPassPrice
            };

            _context.FishingPasses.Add(pass);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FishingPassDto>> GetMyPassesAsync(ClaimsPrincipal userClaims)
        {
            var email = userClaims.FindFirstValue(ClaimTypes.Email);

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return await _context.FishingPasses
                .Where(p => p.UserId == user.Id)
                .Select(p => new FishingPassDto
                {
                    Id = p.Id,
                    FishingSpotName = p.FishingSpot.Name,
                    ValidDate = p.ValidDate,
                    Price = p.Price,
                    PurchaseDate = p.PurchaseDate
                }).ToListAsync();
        }
    }
}
