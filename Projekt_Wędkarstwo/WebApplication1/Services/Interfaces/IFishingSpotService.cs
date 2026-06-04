using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IFishingSpotService
    {
        Task<IEnumerable<FishingSpotDto>> GetAllAsync();
        Task<FishingSpotDto?> GetByIdAsync(int id);
    }
}
