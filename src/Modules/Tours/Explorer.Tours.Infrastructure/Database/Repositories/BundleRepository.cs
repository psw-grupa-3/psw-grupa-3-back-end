using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.Bundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class BundleRepository : CrudDatabaseRepository<Bundle, ToursContext>
    {
        private readonly ToursContext _context;
        public BundleRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
