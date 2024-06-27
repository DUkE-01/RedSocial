using AutoMapper;
using Microsoft.AspNetCore.Http;
using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.Interfaces.Repositories;
using RedSocial.Core.Application.Interfaces.Services;
using RedSocial.Core.Application.ViewModels.Following;
using RedSocial.Core.Domain.Entities;
using RedSocial.Core.Application.Helpers;

namespace RedSocial.Core.Application.Services
{
    public class FollowService : IAmigosService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IAmigoRepository _followingRepository;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;
        private readonly IUserApplication _userApplication;

        public FollowService(IUserApplication userApplication, IAmigoRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _followingRepository = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _userApplication = userApplication;

        }

       


        public async Task<AmigoViewModel> Follow(string ID)
        {
            SaveAmigoViewModel vm = new();

            vm.UserMainID = userViewModel.Id;
            vm.FollowingUserID = ID;
            vm.Created = DateTime.Now;
            var mapModel = _mapper.Map<Amigo>(vm);
            mapModel = await _followingRepository.AddAsync(mapModel);

            var mapModels = _mapper.Map<AmigoViewModel>(mapModel);

            return mapModels;
        }

        public async Task UnFollow(int ID)
        {
            var relationship = await _followingRepository.GetByIdAsync(ID);
            await _followingRepository.DeleteAsync(relationship);

        }




    }
}
