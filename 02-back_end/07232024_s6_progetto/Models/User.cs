#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
	public class User
	{
        [Key]
        public int UserID { get; set; }

        [StringLength(50, ErrorMessage = "Il nome non deve superare i 50 caratteri")]
        public string? FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Il cognome non deve superare i 50 caratteri")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "L'username è obbligatoria")]
        [StringLength(25, ErrorMessage = "Il nome utente non può superare i 25 caratteri.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Formato email non valido")]
        [StringLength(50, ErrorMessage = "L'email non può superare i 50 caratteri")]
        public string? Email { get; set; }

        [StringLength(255, ErrorMessage = "La hash della password non può superare i 255 caratteri.")]
        public string PasswordHash { get; set; }

        [StringLength(255, ErrorMessage = "Il sale della password non può superare i 255 caratteri.")]
        public string PasswordSalt { get; set; }
    }
}

