using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public enum TourExecutionStatus {ACTIVE = 1, COMPLETED, ABANDONED}
    public class TourExecution: Entity
    {
        public long TourId { get; init; }
        public TourExecutionStatus Status { get; init; }
        public Position Position { get; init; }

        public TourExecution(long tourId, TourExecutionStatus status)
        {
            TourId = tourId;
            Status = status;
        }

    }
}
