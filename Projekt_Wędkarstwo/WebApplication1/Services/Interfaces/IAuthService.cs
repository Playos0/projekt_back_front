using WebApplication1.Models.DTOs;
namespace WebApplication1.Services.Interfaces
{
    public interface IAuthService
    {
        bool Register(RegisterRequestDto dto);

        string? Login(string email, string password);
    }
}
