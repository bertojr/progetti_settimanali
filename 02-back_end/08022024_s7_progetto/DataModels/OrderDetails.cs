using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
	public class OrderDetails
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public required int OrderDetailsID { get; set; }

		public required Orders Order { get; set; }

        public required Products Products { get; set; }

		[Required]
		public required int Quantity { get; set; } = 1;

		public required decimal UnitPrice { get; set; }
    }
}

