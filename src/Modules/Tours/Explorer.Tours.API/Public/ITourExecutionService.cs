using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Dtos.Tours;
using FluentResults;

namespace Explorer.Tours.API.Public
{
    public interface ITourExecutionService
    {
        Result<TourExecutionDto> QuitExecution(int  executionId);
        Result<TourExecutionDto> UpdatePosition(int executionId, PositionDto position);
        Result<TourExecutionDto> StartExecution(int tourId);
        Result<PagedResult<TourExecutionDto>> GetPaged(int page, int pageSize);
      
    }
}
