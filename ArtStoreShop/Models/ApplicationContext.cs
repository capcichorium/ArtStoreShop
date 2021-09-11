using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ArtStoreShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { id = 1, name = adminRoleName };
            Role userRole = new Role { id = 2, name = userRoleName };
            User adminUser = new User { id = 1, email = adminEmail, password = adminPassword, roleId = adminRole.id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);

            string name1 = "Футболки 3D";
            string desc1 = "is t-shirt ";

            var tshirt = new Category { id = 1, name = name1, desc = desc1 };

            modelBuilder.Entity<Category>().HasData(new Category[] { tshirt});
            base.OnModelCreating(modelBuilder);


        }
    }
}
