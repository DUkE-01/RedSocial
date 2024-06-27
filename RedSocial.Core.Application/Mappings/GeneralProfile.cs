using AutoMapper;
using RedSocial.Core.Application.Dtos.Account;
using RedSocial.Core.Application.ViewModels.Comment;
using RedSocial.Core.Application.ViewModels.Following;
using RedSocial.Core.Application.ViewModels.Post;
using RedSocial.Core.Application.ViewModels.Usuario;
using RedSocial.Core.Domain.Entities;

namespace RedSocial.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
  

            
            //Usuario mapeo

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateUserRequest, UpdateUserViewModel>()
                  .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
             .ReverseMap();

            CreateMap<Post, PostViewModel>()
              .ForMember(dest => dest.CommentList, opt => opt.Ignore())
              .ForMember(dest => dest.UserName, opt => opt.Ignore())
              .ReverseMap()
              .ForMember(dest => dest.Comentarios, opt => opt.Ignore())
             ;

            CreateMap<Post, SavePostViewModel>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PostViewModel, SavePostViewModel>()
              .ForMember(dest => dest.Photo, opt => opt.Ignore())
              .ReverseMap();


        }
    }
}
