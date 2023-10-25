using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourRepository : CrudDatabaseRepository<Tour, ToursContext>, ITourRepository
    {
        private readonly ToursContext _context;
        public TourRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
