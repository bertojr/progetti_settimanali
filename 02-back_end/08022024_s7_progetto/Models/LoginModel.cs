using System;
using System.ComponentModel.DataAnnotations;

namespace _08022024_s7_progetto.Models
{
	public class LoginModel
	{
		[Required]
		public required string Username { get; set; }

		[Required]
		public required string Password { get; set; }
	}
}

