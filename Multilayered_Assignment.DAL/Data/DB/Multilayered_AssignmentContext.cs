using Microsoft.EntityFrameworkCore;
using Multilayered_Assignment.Models;
using System.Collections.Generic;


namespace Multilayered_Assignment.Data
{
    public class Multilayered_AssignmentContext : DbContext
    {
        public Multilayered_AssignmentContext(DbContextOptions<Multilayered_AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Multilayered_Assignment.Models.ProductTShirtViewModel> ProductTShirtViewModel { get; set; }

        public DbSet<Multilayered_Assignment.Models.ShoppingItemViewModel> ShoppingItemViewModel { get; set; }
        public DbSet<Multilayered_Assignment.Models.ShoppingBagViewModel> ShoppingBagViewModel { get; set; }
        public DbSet<Multilayered_Assignment.Models.LoginViewModel> LoginViewModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Login
            modelBuilder.Entity<LoginViewModel>()
                .HasKey(l => new { l.LoginId });
            modelBuilder.Entity<LoginViewModel>()
                .HasAlternateKey(l => new { l.UserName });
            modelBuilder.Entity<LoginViewModel>() // one on one relation shoppingbag
               .HasOne(spb => spb.ShoppingBagViewModel)
               .WithOne(l => l.LoginViewModel)
               .HasForeignKey<LoginViewModel>(l => l.ShoppingBagId);

            //Shopping Bag
            modelBuilder.Entity<ShoppingBagViewModel>()
               .HasKey(spb => new { spb.ShoppingBagId });
            modelBuilder.Entity<ShoppingBagViewModel>() // one on one relation Login
               .HasOne(l => l.LoginViewModel)
               .WithOne(spb => spb.ShoppingBagViewModel)
               .HasForeignKey<ShoppingBagViewModel>(spb => spb.LoginId);
            modelBuilder.Entity<ShoppingBagViewModel>() // one on many relation shoppingitem
               .HasMany(spb => spb.Items)
               .WithOne(spi => spi.ShoppingBag)
               .HasForeignKey(spi => spi.ShoppingBagId);

            //Shopping Item
            modelBuilder.Entity<ShoppingItemViewModel>()
               .HasKey(spi => new { spi.ID });
            modelBuilder.Entity<ShoppingItemViewModel>()
               .HasOne(spi => spi.ShoppingBag)
               .WithMany(spb => spb.Items)
               .HasForeignKey(spi => spi.ShoppingBagId);
            modelBuilder.Entity<ShoppingItemViewModel>()
               .HasOne(spi => spi.Product);

            //Product
            modelBuilder.Entity<ProductTShirtViewModel>()
               .HasKey(wd => new { wd.ID });


            IList<ProductTShirtViewModel> defaultStandards = new List<ProductTShirtViewModel>();
            for (int i = 1; i < 15; i++)
            {
                defaultStandards.Add(new ProductTShirtViewModel() { ID = i * 5 - 4, Name = "Red Shirt", Price = 502, Picture = "red-shirt.jpg" });
                defaultStandards.Add(new ProductTShirtViewModel() { ID = i * 5 - 3, Name = "Xmas Shirt", Price = 302, Picture = "christmas-shirt.jpg" });
                defaultStandards.Add(new ProductTShirtViewModel() { ID = i * 5 - 2, Name = "King Shirt", Price = 1999, Picture = "king-shirt.jpg" });
                defaultStandards.Add(new ProductTShirtViewModel() { ID = i * 5 - 1, Name = "Tom&Jerry Shirt", Price = 1999, Picture = "Tom-Jerry-shirt.jpg" });
                defaultStandards.Add(new ProductTShirtViewModel() { ID = i * 5, Name = "Plain Shirt", Price = 1999, Picture = "plain-shirt.jpg" });
            }
            modelBuilder.Entity<ProductTShirtViewModel>().HasData(defaultStandards);

            IList<LoginViewModel> defaultUsers = new List<LoginViewModel>();
            defaultUsers.Add(new LoginViewModel() { LoginId = 1, UserName = "admin1", Role = "admin", Password = "admin" });
            defaultUsers.Add(new LoginViewModel() { LoginId = 2, UserName = "arthur", Role = "normal", Password = "arthur" });
            modelBuilder.Entity<LoginViewModel>().HasData(defaultUsers);
        }
    }
}
