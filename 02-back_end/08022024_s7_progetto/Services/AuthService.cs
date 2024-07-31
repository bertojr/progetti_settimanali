// Disbilita l'avviso del compilato c# di un valore nullable
#pragma warning disable CS8603 
using System.Security.Cryptography;
using System.Text;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using _08022024_s7_progetto.Models;

namespace _08022024_s7_progetto.Services
{
	public class AuthService : IAuthService
	{
        private readonly IUserService _userService;

        // costrutto che inizializza il contesto del database
        public AuthService(IUserService userService)
		{
            _userService = userService;
		}

        // metodo per effettuare il login di un utente
        public async Task<User> Login(string username, string password)
        {
            var user = await _userService.GetByUsername(username);

            // se l'utente esiste e la password è verificata ritorna l'utente
            if(user != null && VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            {
                return user;
            }

            // altrimenti ritorna null
            return null;
        }

        // metodo per registrare un nuovo utente
        public User Register(UserDto userDto)
        {
            // hash e salt della password
            var (hash, salt) = HashPassword(userDto.Password);

            // creazione di un nuovo oggetto utente
            var newUser = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _userService.Create(newUser);

            return newUser;
        }

        // metodo privato per generare hash e salt della password
        private (string hash, string salt) HashPassword(string password)
        {
            // usa HMACSHA512 per generare il salt
            using var hmac = new HMACSHA512();
            var salt = Convert.ToBase64String(hmac.Key);
            var hash = ComputedHash(password, hmac.Key);
            return (hash, salt);
        }

        // metodo privato per calcolare l'hash della password usando il salt fornito
        private string ComputedHash(string password, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        // metodo privato per verificare se la password fornita corrisponde a
        // quella memorizzata
        private bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            var salt = Convert.FromBase64String(storedSalt);
            var hash = ComputedHash(password, salt);
            return storedHash == hash;
        }
    }
}

