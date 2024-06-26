

namespace RedSocial.Core.Domain.Entities
{
    public class User
    {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Password { get; set; }
            public string ProfilePictureUrl { get; set; }
            public bool IsActive { get; set; }
            public ICollection<Post> Posts { get; set; }
            public ICollection<Amigo> Friends { get; set; }
    }
}
