using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class PointRepository : CrudDatabaseRepository<Points, ToursContext>, IPointRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<Points> _dbSet;
        public PointRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<Points>();
        }

        public List<PointsDto> GetByTourId(int id)
        {
           return  _dbSet.Select(x => new PointsDto
            {
                Id = x.Id,
                Longitude = x.Longitude,
                Latitude = x.Latitude,
                Name = x.Name,
                Description = x.Description,
                Picture = x.Picture,
                TourId = x.TourId
            })
            .Where(x => x.TourId == id)
            .ToList();
        }
    }
}
