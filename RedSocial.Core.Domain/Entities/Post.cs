using RedSocial.Core.Domain.Common;


namespace RedSocial.Core.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string? VideoUrl { get; set; }
        public string? ImageURL { get; set; }
        public string Caption { get; set; }
        public string UserID { get; set; }

        //Navigation properties

        public ICollection<Comentario>? Comentarios { get; set; }
    }
}
