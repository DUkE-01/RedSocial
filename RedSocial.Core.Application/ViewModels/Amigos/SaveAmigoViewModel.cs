

using System.ComponentModel.DataAnnotations;

namespace RedSocial.Core.Application.ViewModels.Following
{
    public class SaveAmigoViewModel
    {

       

       
        public int ID { get; set; }
        public DateTime? Created { get; set; }
        public string? UserMainID { get; set; }      
        public string FollowingUserID { get; set; }
    }
}
