using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
	public class Products
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public required int ProductID { get; set; }

		[Required]
		[StringLength(50)]
		public required string Name { get; set; }

		[Required]
		[StringLength(128)]
        public required string Photo { get; set; }

		[Range(0, 100)]
		public decimal Price { get; set; } = 0;

		[Range(0, 60)]
		public required int DeliveryTimeInMinutes { get; set; }

		public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
    }
}

