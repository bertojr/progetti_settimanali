using System;
namespace _07232024_s6_progetto.Interfaces
{
	public interface IDao<T>
	{
		// Crea una nuova istanza dell'entità
		public T Create(T entity);

		// Legge un'entità esistente basata su un ID
		public T Read(int id);

		// Aggiorno un'entità esistente
		public T Update(T entity);

		// Elimina un'entità esistente basata su un ID
		public void Delete(int id);

		// Restituisce tutte le istanze dell'entità
		public List<T> GetAll();
	}
}

