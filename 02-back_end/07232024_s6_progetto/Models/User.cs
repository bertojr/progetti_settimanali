using System;
namespace _07232024_s6_progetto.Models
{
	public class User
	{
        public int UserID { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Username { get; set; }
        public int Email { get; set; }
        public int PasswordHash { get; set; }
        public int PasswordSalt { get; set; }
    }
}

