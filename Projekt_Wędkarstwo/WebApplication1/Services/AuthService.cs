using System;
using WebApplication1.Services.Interfaces;
using WebApplication1.Models;
using System.Collections.Concurrent;

namespace WebApplication1.Services
{
    public class AuthService: IAuthService
    {
        //tu będzie jakaś baza danych
        private readonly IPasswordService _passwordService;
        private readonly AppDbContext _context;

        public AuthService(IPasswordService passwordService, AppDbContext context)
        {
            _passwordService = passwordService;
            _context = context;
        }


        public bool Register(string email, string password)
        {
            if (_context.User.Any(u => u.Email == email))
            {
                return false;
            }

            var hashedPassword = _passwordService.HashPassword(password);

            var newUser = new User
            {
                Name = email,
                Email = email,
                HashedPassword = hashedPassword
            };
    
            _context.User.Add(newUser);
            _context.SaveChanges();

            return true; // Rejestracja udana
        }

        public bool Login(string email, string password)
        {
            var user = _context.User.FirstOrDefault(user => user.Email == email);
            if (user == null) 
            {
                return false;
            }

            return _passwordService.VerifyPassword(password, user.HashedPassword);

        }

    }
}
