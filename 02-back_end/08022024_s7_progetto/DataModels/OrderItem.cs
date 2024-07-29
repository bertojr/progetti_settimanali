using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
	public class OrderItem
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int OrderItemID { get; set; }

        public required Order Order { get; set; }

        public required Product Product { get; set; }

        [Required]
        public required int Quantity { get; set; } = 1;

        public required decimal UnitPrice { get; set; }
    }
}

