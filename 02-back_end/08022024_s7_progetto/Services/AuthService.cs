using System;
using System.Security.Cryptography;
using System.Text;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using _08022024_s7_progetto.Models;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Service
{
	public class AuthService : IAuthService
	{
        private readonly ApplicationDbContext _dbContext;

		public AuthService(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public User Login(string username, string password)
        {
            var user = _dbContext.Users
                .AsNoTracking()
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Username == username);
            if(user != null && VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }

        public User Register(UserDto userDto)
        {
            var (hash, salt) = HashPassword(userDto.Password);
            var newUser = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();
            return newUser;
        }

        private (string hash, string salt) HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = ComputedHash(password, hmac.Key);
            return (hash, salt);
        }

        private string ComputedHash(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var salt = Convert.FromBase64String(storedSalt);
            var hash = ComputedHash(password, salt);
            return storedHash == hash;
        }
    }
}

