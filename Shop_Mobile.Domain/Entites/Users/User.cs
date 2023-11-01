namespace Shop_Mobile.Domain.Entites.Users
{
    public class User
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }


    }
}
