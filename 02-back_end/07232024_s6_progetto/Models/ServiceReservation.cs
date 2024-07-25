#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07232024_s6_progetto.Models
{
	public class ServiceReservation
	{
        [Key]
        public int ServiceReservationID { get; set; }

        [Required(ErrorMessage = "L'ID della prenotazione è obbligatoria")]
        public int ReservationID { get; set; }

        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }

        [Required(ErrorMessage = "L'ID del servizio aggiuntivo è obbligatorio")]
        public int AdditionalServiceID { get; set; }

        [ForeignKey("AdditionalServiceID")]
        public AdditionalService AdditionalService { get; set; }

        [Required(ErrorMessage = "La data è obbligatoria")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La quanità è obbligatoria")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantità deve essere un " +
            "valore non negativo.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Il prezzo totale è obbligatorio.")]
        [Range(0, 9999999999.99, ErrorMessage = "Il prezzo totale deve essere " +
            "un valore tra 0 e 9999999999.99.")]
        public decimal TotalPrice { get; set; }
    }
}

