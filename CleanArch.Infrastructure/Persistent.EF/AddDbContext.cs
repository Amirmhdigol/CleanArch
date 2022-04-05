using CleanArch.Domain.OrdersAgg;
using CleanArch.Domain.Products;
using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.Shared;
using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.EF
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().OwnsOne(a => a.Price, option =>
            {
                option.Property(b => b.Value).HasColumnName("RialPrice");
            });
            modelBuilder.Entity<Product>().OwnsOne(a => a.Money);
            modelBuilder.Entity<User>().OwnsOne(a => a.PhoneNumber);

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
