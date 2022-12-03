using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.Data
{
    public class StoreContext : IdentityDbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AuthorOfBooks> Authors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<Write> Writes { get; set; }
        public DbSet<SupplierRep> SupplierReps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<AuthorOfBooks>().ToTable("AuthorOfBooks");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<BookCategory>().ToTable("Category");
            modelBuilder.Entity<Write>().ToTable("Write");
            modelBuilder.Entity<SupplierRep>().ToTable("SupplierRep");

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@email.com",
                    Email = "admin@email.com",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    NormalizedUserName = "ADMIN@EMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Password20?")
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

        }

        public DbSet<BookStoreApp.Models.SupplierRep> SupplierRep { get; set; }



        //public DbSet<BookStoreApp.Models.Books> Books { get; set; } = default!;
    }
}
