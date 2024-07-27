using System;
using System.Security.Cryptography;
using System.Text;
using _07232024_s6_progetto.DAO;
using _07232024_s6_progetto.Interfaces;
using _07232024_s6_progetto.Models;

namespace _07232024_s6_progetto.Services
{
	public class UserService : IUserService
	{
		private readonly UserDao _userDao;

		public UserService(UserDao userDao)
		{
			_userDao = userDao;
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

			return _userDao.Create(newUser);
		}

		public User Login(string username, string password)
		{
            var user = _userDao.GetAll().FirstOrDefault(u => u.Username == username);
            if (user != null && VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            return null;
        }

        public List<User> GetAllUsers() => _userDao.GetAll();

        public User GetById(int id) => _userDao.Read(id);

        public void Update(User user) => _userDao.Update(user);

        public void Delete(int id) => _userDao.Delete(id);

        private (string hash, string salt) HashPassword(string password)
		{
            using var hmac = new HMACSHA512();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return (hash, salt);
        }

        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using var hmac = new HMACSHA512(Convert.FromBase64String(storedSalt));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            return storedHash == computedHash;
        }
    }
}

