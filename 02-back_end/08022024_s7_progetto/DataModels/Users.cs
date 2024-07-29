using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _08022024_s7_progetto.DataModels
{
	public class Users
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public required int UserID { get; set; }

        [Required]
        [StringLength(50)]
		public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public required string Username { get; set; }

        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(255)]
        public required string PasswordHash { get; set; }

        [StringLength(255)]
        public required string PasswordSalt { get; set; }

        public List<Roles> Roles { get; set; } = new List<Roles>();
    }
}

