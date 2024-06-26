

using System.ComponentModel.DataAnnotations;

namespace RedSocial.Core.Application.ViewModels.Usuario
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Debe colocar el correo del usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
