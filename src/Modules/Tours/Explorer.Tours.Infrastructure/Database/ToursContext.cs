using System.Reflection.Emit;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.EntityFrameworkCore;
using Object = Explorer.Tours.Core.Domain.Object;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<TouristEquipment> TouristEquipment { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<DbEntity<Tour>> Tours { get; set; }
    public DbSet<DbEntity<Guide>> Guides { get; set; }
    public DbSet<TourReview> TourReviews { get; set; }
    public DbSet<TouristPosition> TouristPositions { get; set; }
    public DbSet<EquipmentManagment> EquipmentManagements { get; set; }
    public DbSet<Core.Domain.Object> Objects { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<DbEntity<TourExecution>> TourExecutions { get; set; }
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

        modelBuilder.Entity<DbEntity<Tour>>().ToTable("Tours");
        modelBuilder.Entity<DbEntity<Tour>>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

        modelBuilder.Entity<DbEntity<Guide>>().ToTable("Guides");
        modelBuilder.Entity<DbEntity<Guide>>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

        modelBuilder.Entity<DbEntity<TourExecution>>().ToTable("TourExecutions");
        modelBuilder.Entity<DbEntity<TourExecution>>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");

    }
}