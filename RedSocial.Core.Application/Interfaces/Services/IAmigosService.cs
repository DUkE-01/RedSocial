using RedSocial.Core.Application.ViewModels.Following;
using RedSocial.Core.Domain.Entities;

namespace RedSocial.Core.Application.Interfaces.Services
{
    public interface IAmigosService
    {
        Task<AmigoViewModel> Follow(string ID);

        Task UnFollow(int ID);
    }
}
