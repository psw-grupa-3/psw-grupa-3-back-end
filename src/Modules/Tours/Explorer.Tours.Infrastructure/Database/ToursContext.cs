using Explorer.Tours.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database;

public class ToursContext : DbContext
{
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Problem> Problems { get; set; }
    public DbSet<Points> Points { get; set; }
    public DbSet<TouristEquipment> TouristEquipment { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourReview> TourReviews { get; set; }
    public DbSet<EquipmentManagment> EquipmentManagements { get; set; }
    public ToursContext(DbContextOptions<ToursContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("tours");
    }
}