using System.ComponentModel.DataAnnotations;

namespace Dyder.Domain.Entities.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name é obrigatório")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
    }
}
