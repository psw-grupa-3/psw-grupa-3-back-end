using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;

namespace Explorer.Tours.Core.UseCases
{
    public class TourExecutionService: CrudService<TourExecutionDto, TourExecution>, ITourExecutionRepository, ITourExecutionService
    {
        private readonly ITourExecutionRepository _repository;
        public TourExecutionService(ICrudRepository<TourExecution> crudRepository, IMapper mapper, ITourExecutionRepository _tourExecutionRepository) : base(crudRepository, mapper)
        {
            _repository = _tourExecutionRepository;
        }
    }
}
