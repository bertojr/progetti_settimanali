using System;
namespace _07232024_s6_progetto.Models
{
	public class Reservation
	{
        public int ReservationID { get; set; }
        public string CF { get; set; }
        public Guest Guest { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Year { get; set; }
        public DateOnly CheckinDate { get; set; }
        public DateOnly CheckoutDate { get; set; }
        public decimal ConfirmationDeposit { get; set; }
        public decimal Rate { get; set; }
        public string Details { get; set; }
    }
}

