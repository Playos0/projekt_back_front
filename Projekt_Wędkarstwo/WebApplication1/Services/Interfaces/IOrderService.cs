using System.Security.Claims;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto, ClaimsPrincipal userClaims);
    }
}
