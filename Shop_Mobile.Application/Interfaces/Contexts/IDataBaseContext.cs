using Microsoft.EntityFrameworkCore;
using Shop_Mobile.Domain.Entites.Products;
using Shop_Mobile.Domain.Entites.Users;

namespace Shop_Mobile.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Category> Categories { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
