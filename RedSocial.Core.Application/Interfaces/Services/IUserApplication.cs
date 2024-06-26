
using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.Dtos.User;


namespace RedSocial.Core.Application.Interfaces.Services
{
    public interface IUserApplication
    {
        Task<UpdateUserResponse> Update(UpdateUserRequest request);
        Task<UserResponse> GetByEmailUser(string email);
        List<UserResponse> GetAllUsers();
        Task<UserResponse> GetByUserName(string UserName);
    }
}
