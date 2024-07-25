#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
	public class AdditionalService
	{
        [Key]
		public int AdditionalServiceID { get; set; }

        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [StringLength(100, ErrorMessage = "La descrizione non può superare i 100 caratteri")]
        public string Description { get; set; }

        [Range(0, 999999999999.99, ErrorMessage = "Il prezzo deve essere un " +
            "valore tra 0 e 999999999999.99.")]
        public decimal Price { get; set; }
    }
}

