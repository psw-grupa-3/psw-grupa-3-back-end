using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.TourExecutions
{
    public enum TourExecutionStatus { ACTIVE = 1, COMPLETED, ABANDONED }
    public class TourExecutionDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public TourExecutionStatus Status { get; set; }
        public PositionDto Position { get; set; }
    }
}
