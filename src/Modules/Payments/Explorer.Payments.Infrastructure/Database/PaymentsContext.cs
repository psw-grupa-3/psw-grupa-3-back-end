using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.Order;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database;

public class PaymentsContext : DbContext
{
    public DbSet<Payment> Payments { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<TourPurchaseToken> TourPurchaseTokens { get; set; }
    public DbSet<Sale> Sales { get; set; }

    public PaymentsContext(DbContextOptions<PaymentsContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("payments");
        modelBuilder.Entity<OrderItem>().HasNoKey();
        modelBuilder.Entity<Payment>().ToTable("Payments");
        modelBuilder.Entity<ShoppingCart>().Property(item => item.Items).HasColumnType("jsonb");
        modelBuilder.Entity<Wallet>().ToTable("Wallet");
        modelBuilder.Entity<Sale>().ToTable("Sale");
    }
}
