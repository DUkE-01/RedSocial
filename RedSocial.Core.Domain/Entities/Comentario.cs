
using RedSocial.Core.Domain.Common;

namespace RedSocial.Core.Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public int? IdReferencia { get; set; }
        public int PostID { get; set; }
        public string UsuarioID { get; set; }
        public string? UserIDReplied { get; set; }
        public string Text { get; set; }

        //Navigation Properties
        public Post? Post { get; set; }
    }
}
