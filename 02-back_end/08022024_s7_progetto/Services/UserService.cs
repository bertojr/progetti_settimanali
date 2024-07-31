using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
	public class UserService : IUserService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductService> _logger;

        public UserService(ApplicationDbContext dbContext, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<User> Create(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            try
            {
                await _dbContext.Users.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();
                return newUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del nuovo utente");
                throw;
            }
        }

        public async Task<User> Delete(int id)
        {
            try
            {
                var user = await GetById(id);
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Utente con ID {id} non trovato per eliminazione");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella eliminazione dell'utente");
                throw;
            }
        }

        public async Task<User> Update(int id, User updateUser)
        {
            if (updateUser == null)
            {
                throw new ArgumentNullException(nameof(updateUser));
            }
            try
            {
                var user = await GetById(id);

                user.FirstName = updateUser.FirstName;
                user.LastName = updateUser.LastName;
                user.Username = updateUser.Username;
                user.Email = updateUser.Email;

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Utente con ID {id} non trovato");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nella modifica dell'utente");
                throw;
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var users = await _dbContext.Users
                    .AsNoTracking()
                    .Include(u => u.Roles)
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero di tutti gli utenti");
                throw;
            }
        }

        public async Task<User> GetById(int id)
        {
            try
            {
                var user = await _dbContext.Users
                    .AsNoTracking()
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.UserID == id);
                if (user == null)
                {
                    _logger.LogWarning($"Utente con ID {id} non trovato");
                    throw new KeyNotFoundException($"Utente non ID {id} non trovato");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero dell'utente con ID {id}");
                throw;
            }
        }

        public async Task<User> GetByUsername(string username)
        {
            try
            {
                var user = await _dbContext.Users
                    .AsNoTracking()
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Username == username);
                if (user == null)
                {
                    _logger.LogWarning($"Utente con Username {username} non trovato");
                    throw new KeyNotFoundException($"Utente con username {username} non trovato");
                }

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero dell'utente con username {username}");
                throw;
            }
        }
    }
}

