using System;
using _08022024_s7_progetto.DataModels;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IProductService
	{
		public Task<Product> Create(Product newProduct, IEnumerable<int> selectedIngredients);
		public Task<List<Product>> GetAll();
		public Task<Product> GetById(int id);
		public Task<Product> Update(int id, Product updateProduct);
		public Task<Product> Delete(int id);
	}
}

