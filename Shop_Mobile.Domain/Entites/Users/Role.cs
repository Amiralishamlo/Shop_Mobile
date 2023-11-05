using Shop_Mobile.Domain.Entites.Commons;

namespace Shop_Mobile.Domain.Entites.Users
{
    public class Role:BaseEntity
    {

        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
