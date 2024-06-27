
using Microsoft.Extensions.DependencyInjection;
using RedSocial.Core.Application.Interfaces.Services;
using RedSocial.Core.Application.Services;
using System.Reflection;

namespace RedSocial.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddTransient<IPostService, PostService>();

            services.AddTransient<IUserService, UserService>();

            //services.AddTransient<ICommentService, CommentServices>();

            //services.AddTransient<IFollowingService, FollowService>();








        }
    }
}
