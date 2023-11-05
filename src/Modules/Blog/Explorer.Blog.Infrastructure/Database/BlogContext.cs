using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Blog.Infrastructure.Database;

public class BlogContext : DbContext
{
    public DbSet<DbEntity<Core.Domain.Blog>> Blogs {  get; set; }
    public BlogContext(DbContextOptions<BlogContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("blog");


        modelBuilder.Entity<DbEntity<Core.Domain.Blog>>().ToTable("Blogs");
        modelBuilder.Entity<DbEntity<Core.Domain.Blog>>()
            .Property(item => item.JsonObject).HasColumnType("jsonb");
    }
}