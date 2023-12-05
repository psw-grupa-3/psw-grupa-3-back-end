using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.SolvingStrategies;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database
{
    public class EncountersContext: DbContext
    {
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<SocialEncounter> SocialEncounters { get; set; }

        public EncountersContext(DbContextOptions<EncountersContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("encounters");

            modelBuilder.Entity<Encounter>().ToTable("Encounters");
            modelBuilder.Entity<Encounter>().Property(x => x.Location).HasColumnType("jsonb");
            modelBuilder.Entity<Encounter>().Property(x => x.Participants).HasColumnType("jsonb");
            modelBuilder.Entity<Encounter>().Property(x => x.Completers).HasColumnType("jsonb");

            modelBuilder.Entity<SocialEncounter>().ToTable("SocialEncounters");
            modelBuilder.Entity<SocialEncounter>().Property(x => x.Location).HasColumnType("jsonb");
            modelBuilder.Entity<SocialEncounter>().Property(x => x.Participants).HasColumnType("jsonb");
            modelBuilder.Entity<SocialEncounter>().Property(x => x.Completers).HasColumnType("jsonb");
            modelBuilder.Entity<SocialEncounter>().Property(x => x.CurrentlyInRange).HasColumnType("jsonb");
        }

    }
}
