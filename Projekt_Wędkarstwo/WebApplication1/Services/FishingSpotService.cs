using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class FishingSpotService: IFishingSpotService
    {
        private readonly AppDbContext _context;

        public FishingSpotService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FishingSpotDto>> GetAllAsync()
        {
            return await _context.FishingSpots
                .Select(s => new FishingSpotDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Location = s.Location,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    DayPassPrice = s.DayPassPrice,
                    SubscriptionAvailable = s.SubscriptionAvailable
                }).ToListAsync();
        }

        public async Task<FishingSpotDto?> GetByIdAsync(int id)
        {
            return await _context.FishingSpots
                .Where(s => s.Id == id)
                .Select(s => new FishingSpotDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Location = s.Location,
                    Latitude = s.Latitude,
                    Longitude = s.Longitude,
                    DayPassPrice = s.DayPassPrice,
                    SubscriptionAvailable = s.SubscriptionAvailable
                }).FirstOrDefaultAsync();
        }
    }
}
