using System.ComponentModel.DataAnnotations;

namespace Dyder.Domain.Entities.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name é obrigatório")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
    } 
}
