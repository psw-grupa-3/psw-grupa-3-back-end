using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.API.Dtos.TourExecutions;
using FluentResults;

namespace Explorer.Tours.API.Public
{
    public interface ITourExecutionService
    {
        Result<TourExecutionDto> QuitExecution(int  executionId);
        Result<TourExecutionDto> UpdatePosition(int executionId, PositionDto position);
    }
}
