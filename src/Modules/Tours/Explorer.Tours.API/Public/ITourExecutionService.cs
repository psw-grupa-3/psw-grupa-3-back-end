using Explorer.Tours.API.Dtos.TourExecutions;
using FluentResults;

namespace Explorer.Tours.API.Public
{
    public interface ITourExecutionService
    {
        Result<TourExecutionDto> QuitExecution(int  executionId);
        Result<TourExecutionDto> UpdatePosition(int executionId, PositionDto position);
        Result<TourExecutionDto> StartExecution(int tourId);
    }
}
