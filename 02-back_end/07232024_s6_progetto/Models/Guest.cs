#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili

using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
	public class Guest
	{
        public int GuestID { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale " +
            "deve essere di 16 caratteri")]
        public string CF { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il cognome non può superare i 50 " +
            "caratteri")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "La città di residenza non può superare" +
            " i 50 caratteri")]
        public string? CityOfResidence { get; set; }

        [StringLength(50, ErrorMessage = "La provincia di residenza non può " +
            "superare i 50 caratteri")]
        public string? ProvinceOfResidence { get; set; }

        [EmailAddress(ErrorMessage = "Formato email non valido")]
        [StringLength(50, ErrorMessage = "L'email non può superare i 50 caratteri")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Formato telefono non valido")]
        [StringLength(20, ErrorMessage = "Il telefono non può superare i 20 caratteri")]
        public string? Phone { get; set; }

        [Phone(ErrorMessage = "Formato cellulare non valido")]
        [StringLength(20, ErrorMessage = "Il cellulare non può superare i 20 caratteri")]
        public string? MobilePhone { get; set; }
    }
}

