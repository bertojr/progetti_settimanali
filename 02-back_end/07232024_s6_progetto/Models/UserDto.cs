using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
	public class UserDto
	{
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string Username { get; set; }
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

