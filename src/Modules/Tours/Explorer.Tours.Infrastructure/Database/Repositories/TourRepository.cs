using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Newtonsoft.Json;

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
