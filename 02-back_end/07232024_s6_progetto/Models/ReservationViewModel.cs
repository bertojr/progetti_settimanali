using System;
namespace _07232024_s6_progetto.Models
{
	public class ReservationViewModel
	{
        public Reservation Reservation { get; set; }
        public List<ServiceReservation> AdditionalServices { get; set; }
    }
}

