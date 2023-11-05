using Microsoft.EntityFrameworkCore;
using Shop_Mobile.Application.Interfaces.Contexts;
using Shop_Mobile.Common.Roles;
using Shop_Mobile.Domain.Entites.Products;
using Shop_Mobile.Domain.Entites.Users;

namespace Shop_Mobile.Persistence.Contexts
{
    public class DataBaseContext:DbContext , IDataBaseContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserInRole> UserInRoles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyQueryFilter(modelBuilder);
            SeedData(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            modelBuilder.Entity<User>().HasQueryFilter(x =>!x.IsRemoved);
        }

        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
