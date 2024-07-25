#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;


namespace _07232024_s6_progetto.Models
{
	public class Room
	{
        [Key]
        public int RoomID { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "La tipologia è obbligatoria")]
        [StringLength(30, ErrorMessage = "La tipologia non può superare i 30 caratteri")]
        public string Typology { get; set; }
    }
}

