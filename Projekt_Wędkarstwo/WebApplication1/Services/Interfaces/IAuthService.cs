namespace WebApplication1.Services.Interfaces
{
    public interface IAuthService
    {
        bool Register(string email, string password);

        bool Login(string email, string password);
    }
}
