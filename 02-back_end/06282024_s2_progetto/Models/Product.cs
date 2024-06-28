using System.ComponentModel.DataAnnotations;
namespace _06282024_s2_progetto.Models
{
	public class Product
	{
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        public string CoverImage { get; set; }
        
        public string AdditionalImage1 { get; set; }
        public string AdditionalImage2 { get; set; }
    }
}

