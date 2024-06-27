using System;
using System.Collections.Generic;
using System.Linq;


namespace RedSocial.Core.Application.ViewModels.Following
{
    public class AmigoViewModel
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }
        public string UserMainID { get; set; }      

        public string FollowingUserID { get; set; }
        public string NameUserFollowed { get; set; }
        public string LastNameUserFollowed { get; set; }
        public string UsernameUserFollowed { get; set; }

        public string ImageURL { get; set; }
    }
}
