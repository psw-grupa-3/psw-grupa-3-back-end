using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class ProblemRepository : CrudDatabaseRepository<Problem, ToursContext>, IProblemRepository
    {
        private readonly ToursContext _context;
        public ProblemRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
