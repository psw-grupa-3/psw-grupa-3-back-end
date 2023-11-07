using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using FluentResults;

namespace Explorer.Tours.Core.UseCases
{
    public class TourExecutionService: CrudService<TourExecutionDto, TourExecution>, ITourExecutionRepository, ITourExecutionService
    {
        private readonly ITourExecutionRepository _repository;
        public TourExecutionService(ICrudRepository<TourExecution> repository, IMapper mapper, ITourExecutionRepository _tourExecutionRepository) : base(repository, mapper)
        {
            _repository = _tourExecutionRepository;
        }

        public Result<TourExecutionDto> QuitExecution(int executionId)
        {
            var execution = CrudRepository.Get(executionId);
            execution.QuitTourExecution();
            CrudRepository.Update(execution);
            return MapToDto(execution);
        }

        public Result<TourExecutionDto> UpdatePosition(int executionId, PositionDto position)
        {
            var positionDomain = PositionConverter.ToDomain(position);
            var execution = CrudRepository.Get(executionId);
            execution.UpdatePosition(positionDomain);
            CrudRepository.Update(execution);
            return MapToDto(execution);
        }
    }
}
