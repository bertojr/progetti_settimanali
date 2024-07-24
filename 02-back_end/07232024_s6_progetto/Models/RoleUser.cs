using System;
namespace _07232024_s6_progetto.Models
{
	public class RolesUsers
	{
        public int UserID { get; set; }
        public User User { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}

