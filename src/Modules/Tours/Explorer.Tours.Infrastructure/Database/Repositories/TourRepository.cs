using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRepository : CrudDatabaseRepository<Tour, ToursContext>
    {
        private readonly ToursContext _context;
        public TourRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
