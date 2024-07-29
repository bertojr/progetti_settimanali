using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08022024_s7_progetto.DataModels
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int RoleID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}


