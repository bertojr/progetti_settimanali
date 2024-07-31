// Disbilita l'avviso del compilato c# di un valore nullable
#pragma warning disable CS8603 
using System.Security.Cryptography;
using System.Text;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using _08022024_s7_progetto.Models;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
	public class AuthService : IAuthService
	{
        // dichiarazione del contesto del database
        private readonly ApplicationDbContext _dbContext;

        // costrutto che inizializza il contesto del database
		public AuthService(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        // metodo per effettuare il login di un utente
        public User Login(string username, string password)
        {
            // Cerca l'utente nel database includedo anche i suoi ruoli, senza
            // tracciamento delle modifiche
            var user = _dbContext.Users
                .AsNoTracking() // migliora le prestazioni per le olperazioni
                                // di sola lettura
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.Username == username);
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

            // aggiunge il nuovo utente al contesto del database e salva le modifiche
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();

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

