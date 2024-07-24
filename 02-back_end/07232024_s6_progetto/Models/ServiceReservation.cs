using System;
namespace _07232024_s6_progetto.Models
{
	public class ServiceReservation
	{
        public int ServiceReservationID { get; set; }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public int AdditionalServiceID { get; set; }
        public AdditionalService AdditionalService { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

