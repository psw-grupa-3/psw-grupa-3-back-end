using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<DbEntity<Problem>> Problems { get; set; }
    public DbSet<TouristEquipment> TouristEquipment { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<DbEntity<Guide>> Guides { get; set; }
    public DbSet<TouristPosition> TouristPositions { get; set; }
    public DbSet<EquipmentManagment> EquipmentManagements { get; set; }
    public DbSet<PublicRegistrationRequest> PublicRegistrationRequests { get; set; }
    public DbSet<Core.Domain.Object> Objects { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<TourPurchaseToken> TourPurchaseTokens { get; set; }
    public DbSet<TourExecution> TourExecutions { get; set; }
    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
        modelBuilder.Entity<OrderItem>().HasNoKey();
        ConfigureShoppingCarts(modelBuilder);
    }

    private static void ConfigureShoppingCarts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCart>().Property(item => item.Items).HasColumnType("jsonb");

        modelBuilder.Entity<Tour>().ToTable("Tours");
        modelBuilder.Entity<Tour>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

        modelBuilder.Entity<DbEntity<Guide>>().ToTable("Guides");
        modelBuilder.Entity<DbEntity<Guide>>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

        modelBuilder.Entity<TourExecution>().ToTable("TourExecutions");
        modelBuilder.Entity<TourExecution>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

        modelBuilder.Entity<DbEntity<Problem>>().ToTable("Problems");
        modelBuilder.Entity<DbEntity<Problem>>()

            .Property(item => item.JsonObject).HasColumnType("jsonb"); 


    }
}
