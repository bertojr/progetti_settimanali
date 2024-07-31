using _08022024_s7_progetto.DataModels;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IIngredientService
	{
        public Task<Ingredient> Create(Ingredient newIngredient);
        public Task<List<Ingredient>> GetAll();
        public Task<Ingredient> GetById(int id);
        public Task<Ingredient> Update(int id, Ingredient updateIngredient);
        public Task<Ingredient> Delete(int id);
    }
}

