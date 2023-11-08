using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Explorer.Tours.API.Enums.TourEnums;


namespace Explorer.Tours.API.Dtos.TourExecutions
{
    public class TourExecutionDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public TourExecutionStatus Status { get; set; }
        public PositionDto Position { get; set; }
    }
}
