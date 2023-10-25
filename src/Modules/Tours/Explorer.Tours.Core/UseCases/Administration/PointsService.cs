using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class PointsService : CrudService<PointsDto, Points>, IPointsService
    {
        private readonly IPointRepository _pointRepository;
        public PointsService(ICrudRepository<Points> repository, IMapper mapper, IPointRepository pointRepository) : base(repository, mapper) {
            _pointRepository = pointRepository;
        }

        public Result<List<PointsDto>> GetAllForTour(int id)
        {
            return _pointRepository.GetByTourId(id);
        }
    }
}
