using System;
using System.ComponentModel.DataAnnotations;

namespace _07232024_s6_progetto.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "L'username è obbligatorio.")]
        [StringLength(25, ErrorMessage = "L'username non può superare i 25 caratteri.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}


