using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IMembershipService
    {
        Task<IEnumerable<Membership>> GetMembershipsAsync();
        Task BuyMembershipAsync(BuyMembershipDto dto, ClaimsPrincipal userClaim);
        Task<MembershipDto?> GetMyMembershipsAsync(ClaimsPrincipal userClaim);
    }
}
