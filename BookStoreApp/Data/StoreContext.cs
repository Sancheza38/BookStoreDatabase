using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Models;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        }



        //public DbSet<BookStoreApp.Models.Books> Books { get; set; } = default!;
    }
}
