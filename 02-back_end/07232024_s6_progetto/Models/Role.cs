#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
	public class Role
	{
        [Key]
        public int RoleID { get; set; }

        [Required(ErrorMessage = "Il nome del ruolo è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome del ruolo non può superare i 30 caratteri")]
        public string RoleName { get; set; }
    }
}

