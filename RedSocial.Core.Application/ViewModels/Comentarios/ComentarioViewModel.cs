﻿

namespace RedSocial.Core.Application.ViewModels.Comment
{
    public class ComentarioViewModel
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public int? PostID { get; set; }
        public string UserID { get; set; }
        public string? UserIDReplied { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string? UserNameReplied { get; set; }
        public string Content { get; set; }
        public string UserImage { get; set; }
        public int? IdReference { get; set; }
        public List<ComentarioViewModel>? Replies { get; set; }

    }
}
