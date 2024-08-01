using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
	public class RoleService : IRoleService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<RoleService> _logger;

        public RoleService(ApplicationDbContext dbContext, ILogger<RoleService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Role> Create(Role newRole)
        {
            if (newRole == null)
            {
                throw new ArgumentNullException(nameof(newRole));
            }

            try
            {
                await _dbContext.AddAsync(newRole);
                await _dbContext.SaveChangesAsync();
                return newRole;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del nuovo ruolo");
                throw;
            }
        }

        public async Task<Role> Delete(int id)
        {
            try
            {
                var role = await GetById(id);
                _dbContext.Remove(role);
                await _dbContext.SaveChangesAsync();

                return role;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Ruolo con ID {id} non trovato per eliminazione");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella eliminazione del ruolo");
                throw;
            }
        }

        public async Task<Role> Update(int id, Role updateRole)
        {
            if (updateRole == null)
            {
                throw new ArgumentNullException(nameof(updateRole));
            }
            try
            {
                var role = await GetById(id);

                role.Name = updateRole.Name;

                _dbContext.Update(role);
                await _dbContext.SaveChangesAsync();

                return role;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Ruolo con ID {id} non trovato");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nella modifica del ruolo");
                throw;
            }
        }

        public async Task<List<Role>> GetAll()
        {
            try
            {
                var roles = await _dbContext.Roles
                    .AsNoTracking()
                    .ToListAsync();

                return roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero di tutti i ruoli");
                throw;
            }
        }

        public async Task<Role> GetById(int id)
        {
            try
            {
                var role = await _dbContext.Roles
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.RoleID == id);
                if (role == null)
                {
                    _logger.LogWarning($"Ruolo con ID {id} non trovato");
                    throw new KeyNotFoundException($"Ruolo non ID {id} non trovato");
                }

                return role;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero del ruolo con ID {id}");
                throw;
            }
        }
    }
}

