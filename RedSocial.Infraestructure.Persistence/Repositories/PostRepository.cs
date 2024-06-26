using RedSocial.Core.Application.Interfaces.Repositories;
using RedSocial.Core.Domain.Entities;
using RedSocial.Infraestructure.Persistence.Contexts;

namespace RedSocial.Infraestructure.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>,IPostRepository
    {
        private readonly ApplicationContext _dbContext;
        public PostRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
