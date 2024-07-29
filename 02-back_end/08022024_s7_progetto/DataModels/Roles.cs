using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
	public class Roles
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public required int RoleID { get; set; }

		[Required]
		[StringLength(50)]
		public required string Name { get; set; }
	}
}

