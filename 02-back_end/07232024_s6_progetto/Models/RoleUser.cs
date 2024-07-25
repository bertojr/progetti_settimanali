#pragma warning disable CS8618 // Disabilita l'avviso relativo ai campi non nullabili
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _07232024_s6_progetto.Models
{
	public class RoleUser
	{
        [Key, Column(Order = 0)]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [Key, Column(Order = 1)]
        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }
    }
}

