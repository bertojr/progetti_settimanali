using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
    public enum OrderStatus
    {
        InCorso,
        Evaso,
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int OrderID { get; set; }

        public required User User { get; set; }

        [Required]
        [StringLength(100)]
        public required string DeliveryAddress { get; set; }

        public required DateTime OrderDate { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string? Notes { get; set; }

        [Required]
        public required OrderStatus Status { get; set; } = OrderStatus.InCorso;

        public List<OrderItem> Item { get; set; } = new List<OrderItem>();
    }
}

