

namespace RedSocial.Core.Application.ViewModels.Usuario
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageURL { get; set; }

        public string Email { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
