using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _08022024_s7_progetto.Services
{
	public class OrderService : IOrderService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<OrderService> _logger;

        public OrderService(ApplicationDbContext dbContext, ILogger<OrderService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Order> Create(Order newOrder)
        {
            if (newOrder == null)
            {
                throw new ArgumentNullException(nameof(newOrder));
            }

            try
            {
                await _dbContext.AddAsync(newOrder);
                await _dbContext.SaveChangesAsync();
                return newOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella creazione del nuovo ordine");
                throw;
            }
        }

        public async Task<Order> Delete(int id)
        {
            try
            {
                var order = await GetById(id);
                _dbContext.Remove(order);
                await _dbContext.SaveChangesAsync();

                return order;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Ordine con ID {id} non trovato per eliminazione");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore nella eliminazione dell'ordine");
                throw;
            }
        }

        public async Task<List<Order>> GetAll()
        {
            try
            {
                var order = await _dbContext.Orders
                    .AsNoTracking()
                    .Include(o => o.Item)
                    .ToListAsync();

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero di tutti gli ordini");
                throw;
            }
        }

        public async Task<Order> GetById(int id)
        {
            try
            {
                var order = await _dbContext.Orders
                    .AsNoTracking()
                    .Include(o => o.Item)
                    .FirstOrDefaultAsync(o => o.OrderID == id);
                if (order == null)
                {
                    _logger.LogWarning($"Ordine con ID {id} non trovato");
                    throw new KeyNotFoundException($"Ordine non ID {id} non trovato");
                }

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore nel recupero dell'ordine con ID {id}");
                throw;
            }
        }
    }
}

