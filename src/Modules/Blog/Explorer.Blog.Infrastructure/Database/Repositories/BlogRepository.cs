using Explorer.Blog.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Blog.Infrastructure.Database.Repositories
{
    public class BlogRepository: CrudDatabaseRepository<Core.Domain.Blog, BlogContext>, IBlogRepository
    {
        private readonly BlogContext _context;
        private readonly DbSet<Core.Domain.Blog> _dbSet;
        public BlogRepository(BlogContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<Core.Domain.Blog>();
        }
    }
}
