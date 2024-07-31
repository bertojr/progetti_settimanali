using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
	public class IngredientService : IIngredientService 
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductService> _logger;

        public IngredientService(ApplicationDbContext dbContext, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Ingredient> Create(Ingredient newIngredient)
        {
            if (newIngredient == null)
            {
                throw new ArgumentNullException(nameof(newIngredient));
            }

            try
            {
                await _dbContext.Ingredients.AddAsync(newIngredient);
                await _dbContext.SaveChangesAsync();
                return newIngredient;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del nuovo ingrediente");
                throw;
            }
        }

        public async Task<Ingredient> Delete(int id)
        {
            try
            {
                var ingredient = await GetById(id);
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();

                return ingredient;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Ingrediente con ID {id} non trovato per eliminazione");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella eliminazione dell'ingrediente");
                throw;
            }
        }

        public async Task<List<Ingredient>> GetAll()
        {
            try
            {
                var ingredients = await _dbContext.Ingredients
                    .AsNoTracking()
                    .Include(i => i.Products)
                    .ToListAsync();

                return ingredients;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero di tutti gli ingredienti");
                throw;
            }
        }

        public async Task<Ingredient> GetById(int id)
        {
            try
            {
                var ingredient = await _dbContext.Ingredients
                    .AsNoTracking()
                    .Include(i => i.Products)
                    .FirstOrDefaultAsync(i => i.IngredientID == id);
                if (ingredient == null)
                {
                    _logger.LogWarning($"Ingrediente con ID {id} non trovato");
                    throw new KeyNotFoundException($"Ingrediente non ID {id} non trovato");
                }

                return ingredient;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero dell'ingrediente con ID {id}");
                throw;
            }
        }

        public async Task<Ingredient> Update(int id, Ingredient updateIngredient)
        {
            if (updateIngredient == null)
            {
                throw new ArgumentNullException(nameof(updateIngredient));
            }
            try
            {
                var ingredient = await GetById(id);

                ingredient.Name = updateIngredient.Name;
                ingredient.Description = updateIngredient.Description;

                _dbContext.Update(ingredient);
                await _dbContext.SaveChangesAsync();

                return ingredient;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Ingrediente con ID {id} non trovato");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nella modifica dell'ingrediente");
                throw;
            }
        }
    }
}

