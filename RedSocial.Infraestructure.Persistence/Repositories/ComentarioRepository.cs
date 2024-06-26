using RedSocial.Core.Application.Interfaces.Repositories;
using RedSocial.Core.Domain.Entities;
using RedSocial.Infraestructure.Persistence.Contexts;

namespace RedSocial.Infraestructure.Persistence.Repositories
{
    public class ComentarioRepository : GenericRepository<Comentario>, IComentarioRepository
    {
        private readonly ApplicationContext _dbContext;
        public ComentarioRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
