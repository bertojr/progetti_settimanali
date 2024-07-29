using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _08022024_s7_progetto.DataModels
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int IngredientID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}

