using AutoMapper;
using Microsoft.AspNetCore.Http;
using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.Interfaces.Repositories;
using RedSocial.Core.Application.Interfaces.Services;
using RedSocial.Core.Application.ViewModels.Post;
using RedSocial.Core.Domain.Entities;


namespace RedSocial.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
    {
        private readonly AuthenticationResponse user;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PostService(AuthenticationResponse user, IMapper mapper,IPostRepository repository
            ,IHttpContextAccessor httpContextAccessor) : base(repository,mapper)
        {
            this.user = user;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {

            var modelList = await base.GetAllViewModel();
            

            modelList = modelList.Where(p => p.UserID == user.Id).ToList();

            modelList.ForEach(async post => {
                post.UserName = user.UserName;
                post.Name = user.Name;
                post.LastName = user.Lastname;
                post.UserImageURL = user.ImageUrl;
              
            });

            return _mapper.Map<List<PostViewModel>>(modelList).OrderByDescending(i => i.Created).ToList();
        }
    }
}
