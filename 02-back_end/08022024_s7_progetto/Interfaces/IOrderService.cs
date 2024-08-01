using System;
using _08022024_s7_progetto.DataModels;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IOrderService
	{
        public Task<Order> Create(Order newOrder);
        public Task<List<Order>> GetAll();
        public Task<Order> GetById(int id);
        public Task<Order> Delete(int id);
    }
}

