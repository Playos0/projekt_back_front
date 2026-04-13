namespace WebApplication1.Services.Interfaces
{
    public interface IAuthService
    {
        bool Register(string email, string password);

        string? Login(string email, string password);
    }
}
