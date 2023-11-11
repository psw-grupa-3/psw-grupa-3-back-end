using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourExecutionRepository: CrudDatabaseRepository<TourExecution, ToursContext>, ITourExecutionRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<TourExecution> _dbSet;
        public TourExecutionRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<TourExecution>();
        }
    }
}
