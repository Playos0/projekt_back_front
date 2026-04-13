using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IJwtService
    {
            string GenerateToken(User user);
    }
}
