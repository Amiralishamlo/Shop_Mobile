using Shop_Mobile.Domain.Entites.Commons;

namespace Shop_Mobile.Domain.Entites.Users
{
    public class User: BaseEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}
