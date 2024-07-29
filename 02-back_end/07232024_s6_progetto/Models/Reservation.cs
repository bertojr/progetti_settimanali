#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07232024_s6_progetto.Models
{
	public class Reservation
	{
        [Key]
        public int ReservationID { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        public string CF { get; set; }

        [ForeignKey("CF")]
        public Guest Guest { get; set; }

        [Required(ErrorMessage = "Il numero della stanza è obbligatorio.")]
        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public Room Room { get; set; }

        [Required(ErrorMessage = "La data di prenotazione è obbligatoria.")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "L'anno è obbligatorio.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "La data di check-in è obbligatoria.")]
        public DateOnly CheckinDate { get; set; }

        [Required(ErrorMessage = "La data di check-out è obbligatoria.")]
        public DateOnly CheckoutDate { get; set; }

        [Required(ErrorMessage = "Il deposito di conferma è obbligatorio.")]
        [Range(0, 9999999999.99, ErrorMessage = "Il deposito di conferma deve " +
            "essere un valore tra 0 e 9999999999.99.")]
        public decimal ConfirmationDeposit { get; set; }

        [Required(ErrorMessage = "La tariffa è obbligatoria.")]
        [Range(0, 999999999999.99, ErrorMessage = "La tariffa deve essere un " +
            "valore tra 0 e 999999999999.99.")]
        public decimal Rate { get; set; }

        [StringLength(50, ErrorMessage = "I dettagli non possono superare i " +
            "50 caratteri.")]
        public string Details { get; set; }

        public int TotalReservations { get; set; }
    }
}

