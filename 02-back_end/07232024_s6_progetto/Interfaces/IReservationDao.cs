using System;
using _07232024_s6_progetto.Models;

namespace _07232024_s6_progetto.Interfaces
{
	public interface IReservationDao
	{
		public List<Reservation> GetByCf(string cf);
		public List<Reservation> GetAllPensioneCompleta();
	}
}

