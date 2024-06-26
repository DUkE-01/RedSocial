using RedSocial.Core.Application.ViewModels.Following;
using RedSocial.Core.Domain.Entities;

namespace RedSocial.Core.Application.Interfaces.Services
{
    public interface IFollowingService
    {
        Task<FollowingViewModel> Follow(string ID);

        Task<List<FollowingViewModel>> GetAllFollows();
        Task UnFollow(int ID);
    }
}
