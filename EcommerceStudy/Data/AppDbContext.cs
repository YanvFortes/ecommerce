using EcommerceStudy.Models.Products;
using EcommerceStudy.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace EcommerceStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(item => item.Order)
                .WithMany(item => item.OrderItems)
                .HasForeignKey(item => item.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(item => item.Product)
                .WithMany()
                .HasForeignKey(item => item.ProductId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(item => item.Product)
                .WithMany()
                .HasForeignKey(item => item.ProductId);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<IPhone> IPhones { get; set; }
        public DbSet<AirPods> AirPods { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Charger> Chargers { get; set; }
        public DbSet<AppleWatch> AppleWatches { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
