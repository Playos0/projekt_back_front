using System.Security.Claims;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IFishingPassService
    {
        Task BuyPassAsync(BuyFishingPassDto dto, ClaimsPrincipal userClaims);
        Task<IEnumerable<FishingPassDto>> GetMyPassesAsync(ClaimsPrincipal userClaims);
    }
}
