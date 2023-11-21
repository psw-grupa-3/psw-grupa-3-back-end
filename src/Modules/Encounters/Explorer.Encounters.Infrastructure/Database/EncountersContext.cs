﻿using Explorer.Encounters.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Encounters.Infrastructure.Database
{
    public class EncountersContext: DbContext
    {
        public DbSet<Encounter> Encounters { get; set; }

        public EncountersContext(DbContextOptions<EncountersContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("encounter");

            modelBuilder.Entity<Encounter>().ToTable("Encounters");
        }

    }
}