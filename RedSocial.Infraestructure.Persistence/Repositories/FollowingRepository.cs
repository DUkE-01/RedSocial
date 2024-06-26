

using RedSocial.Core.Application.Interfaces.Repositories;
using RedSocial.Core.Domain.Entities;
using RedSocial.Infraestructure.Persistence.Contexts;

namespace RedSocial.Infraestructure.Persistence.Repositories
{
   
    public class FollowingRepository : GenericRepository<Amigo>, IAmigoRepository
    {
        private readonly ApplicationContext _dbContext;
        public FollowingRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
