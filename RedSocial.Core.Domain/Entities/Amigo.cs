

using RedSocial.Core.Domain.Common;

namespace RedSocial.Core.Domain.Entities
{
    public class Amigo : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int UsuarioSeguido { get; set; }

    }
}
