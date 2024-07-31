using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ApplicationDbContext dbContext, ILogger<ProductService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Product> Create(Product newProduct)
        {
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }

            try
            {
                await _dbContext.Products.AddAsync(newProduct);
                await _dbContext.SaveChangesAsync();
                return newProduct;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del prodotto");
                throw;
            }
        }

        public async Task<Product> Delete(int id)
        {
            try
            {
                var product = await GetById(id);
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();

                return product;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Prodotto con ID {id} non trovato per eliminazione");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella eliminazione del prodotto");
                throw;
            }
        }

        public async Task<Product> Update(int id, Product updateProduct)
        {
            if (updateProduct == null)
            {
                throw new ArgumentNullException(nameof(updateProduct));
            }
            try
            {
                var product = await GetById(id);

                product.Name = updateProduct.Name;
                product.Photo = updateProduct.Photo;
                product.Price = updateProduct.Price;
                product.Ingredients = updateProduct.Ingredients;

                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();

                return product;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Prodotto con ID {id} non trovato");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nella modifica del prodotto");
                throw;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                var products = await _dbContext.Products
                    .AsNoTracking()
                    .Include(p => p.Ingredients)
                    .ToListAsync();

                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero di tutti i prodotti");
                throw;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                var product = await _dbContext.Products
                    .AsNoTracking()
                    .Include(p => p.Ingredients)
                    .FirstOrDefaultAsync(p => p.ProductID == id);
                if (product == null)
                {
                    _logger.LogWarning($"Prodotto con ID {id} non trovato");
                    throw new KeyNotFoundException($"Prodotto non ID {id} non trovato");
                }

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero del prodotto con ID {id}");
                throw;
            }
        }
    }
}

