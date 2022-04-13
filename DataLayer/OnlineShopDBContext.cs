using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class OnlineShopDBContext : DbContext
    {
        public OnlineShopDBContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-AT94SBBO\SQLEXPRESS;Database=OnlineShopDBv1J;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=III-PC\SQLEXPRESS;Database=OnlineShopDBv1J;Trusted_Connection=True;");
            // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProductQuantity>().HasKey(opq => new { opq.OrderID, opq.ProductBarcode });


            // base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProductQuantity> OPQs { get; set; }

    }
}
