using System;
using System.ComponentModel.DataAnnotations;

namespace _08022024_s7_progetto.Models
{
	public class UserDto
	{
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}

