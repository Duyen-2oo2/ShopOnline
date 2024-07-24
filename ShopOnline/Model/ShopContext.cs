using ShopOnline.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using ShopBanHang.Models;
namespace ShopOnline.Model
{
    public class ShopContext : DbContext
    {
        protected string connect_str = @"Data Source=WIN-19JQD0JH2B5;
                                         Initial Catalog=ShopDB;
                                         Integrated Security=True;
                                         Encrypt=False";
        public DbSet<Product> Product{ set; get; }      
        public DbSet<Category> Category { set; get; }   
        
        public DbSet<Account> Account { set; get; }

        public DbSet<ItemOrder> ItemOrder { set; get; }

        public DbSet<ItemOrderEntry> ItemOrderEntry { set; get; }

        public DbSet<Order> Order { set; get; }

        public DbSet<OrderEntry> OrderEntry { set; get; }

        public DbSet<Payment> Payment { set; get; }

        public DbSet<Ship> Ship { set; get; }

        public DbSet<Supplier> Supplier { set; get; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Tạo ILoggerFactory
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseSqlServer(connect_str)           
                          .UseLoggerFactory(loggerFactory);     

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ItemOrder>( entity =>
                {
                   entity.HasKey(e => new { e.OId, e.ProductId }); 
                   entity.HasOne(e => e.Order)
                         .WithMany()
                         .HasForeignKey(e => e.OId);
                   entity.HasOne(e => e.Product)
                         .WithMany()
                         .HasForeignKey(e => e.ProductId);
                });
            modelBuilder.Entity<ItemOrderEntry>(entity =>
            {
                entity.HasKey(e => new { e.OEId, e.ProductId });
                entity.HasOne(e => e.OrderEntry)
                      .WithMany()
                      .HasForeignKey(e => e.OEId);
                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId);
            });

        }



    }
}
