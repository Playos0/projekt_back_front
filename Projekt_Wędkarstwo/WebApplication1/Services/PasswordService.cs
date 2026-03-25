using System;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class PasswordService: IPasswordService
    {
        private readonly IPasswordHasher<object> _hasher;

        //konstruktor
        public PasswordService(IPasswordHasher<object> hasher)
        {
            _hasher = hasher;
        }

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null!, password);
        }

        public bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);

            return result == PasswordVerificationResult.Success;
        }

    }
}
