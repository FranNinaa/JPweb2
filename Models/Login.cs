using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace JPweb.Models
{
    public class Login
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite seu Email !")]

        public string? Email { get; set; }


        [Required(ErrorMessage = "Digite sua Senha !")]

        public string? Senha { get; set; }
      

    }
}
