using System;
using WebApplication1.Services.Interfaces;
using WebApplication1.Models;
using System.Collections.Concurrent;
using WebApplication1.Data;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public class AuthService: IAuthService
    {
        //tu będzie jakaś baza danych
        private readonly IPasswordService _passwordService;
        private readonly AppDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthService(IPasswordService passwordService, AppDbContext context, IJwtService jwtService)
        {
            _passwordService = passwordService;
            _context = context;
            _jwtService = jwtService;
        }


        public bool Register(RegisterRequestDto dto)
        {
            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                return false;
            }

            var hashedPassword = _passwordService.HashPassword(dto.Password);

            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                HashedPassword = hashedPassword,
                Address = new Address
                {
                    City = dto.Address.City,
                    Street = dto.Address.Street,
                    HouseNumber = dto.Address.HouseNumber,
                    PostalCode = dto.Address.PostalCode
                }
            };
    
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return true; // Rejestracja udana
        }

        public string? Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email == email);
            if (user == null) 
            {
                return null;
            }

            if(!_passwordService.VerifyPassword(password, user.HashedPassword))
            {
                return null;
            }

            return _jwtService.GenerateToken(user);
        }

    }
}
