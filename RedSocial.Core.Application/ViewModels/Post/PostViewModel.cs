

using RedSocial.Core.Application.ViewModels.Comment;


namespace RedSocial.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int ID { get; set; }

        public string? VideoUrl { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public string UserID { get; set; }
        public string? ImageURL { get; set; }
		public string? UserImageURL { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public List<ComentarioViewModel>? CommentList { get; set; }
    }
}
