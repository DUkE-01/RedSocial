

namespace RedSocial.Core.Application.ViewModels.Usuario
{
    public class ResetPasswordViewModel
    {
        public string? Token { get; set; }

        public string? Password { get; set; }
        public string? Email { get; set; }

        public bool? HasError { get; set; }
        public string? Error { get; set; }
    }
}
