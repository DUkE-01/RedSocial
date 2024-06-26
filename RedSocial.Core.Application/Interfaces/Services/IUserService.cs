using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.ViewModels.Usuario;

namespace RedSocial.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task<UpdateUserResponse> Update(UpdateUserViewModel request);
        Task SignOutAsync();
    }
}
